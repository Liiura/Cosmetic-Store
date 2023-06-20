using BlazorAppServer.Interfaces;
using BlazorAppShared;
using BlazorAppShared.DTO;
using BlazorAppShared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppServer.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _context;
        public ClientRepository(ApplicationDbContext context)
        {

            _context = context;

        }
        async Task<ResponsePayload> IClientRepository.CreateClient(CreateEditClientDTO clientDTO)
        {
            var payload = new ResponsePayload();
            try
            {
                using (var context = _context)
                {
                    var isEmployeeCreated = context.Client.FirstOrDefault(x => x.Name == clientDTO.Name);
                    if (isEmployeeCreated == null)
                    {
                        var client = new Client { Name = clientDTO.Name, CreatedDate = DateTime.Now };
                        await context.Client.AddAsync(client);
                        await context.SaveChangesAsync();
                        payload.Status = 201;
                        payload.Message = "Client was inserted";
                    }
                    else
                    {
                        payload.Status = 400;
                        throw new Exception("The employee cannot be inserted");
                    }
                }
            }
            catch (Exception ex)
            {
                payload.Status = payload.Status != null ? payload.Status : 500;
                payload.Message = ex?.InnerException?.Message ?? ex.Message;
                
            }
            return payload;
        }

        async Task<List<ClientSeparationProductDTO>> IClientRepository.GetAllSeparationProducts(int clientId)
        {
            using(var context = _context) {
            
                var allClientSepartionProduct = await context.ClientSeparationProduct.Where(x => x.ClientId == clientId).Select(x => new ClientSeparationProductDTO
                {
                    Id = x.Id,
                    AvailablePromotion = x.Promotion != null ? x.Promotion.PromotionName : null,
                    ClientId = clientId,
                    ClientSeparationProductDetailDTOs = x.ClientSeparationProductDetails != null ? x.ClientSeparationProductDetails.Select(x => new ClientSeparationProductDetailDTO {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    SeparatedQuantity = x.SeparatedQuantity
                    }).ToList() : new List<ClientSeparationProductDetailDTO>(),
                    SeparatedDate = x.CreatedDate
                }).ToListAsync();
                return allClientSepartionProduct;
            }
        }

        async Task<ResponsePayload<PromotionDTO>> IClientRepository.GetAvailablePromotionBySeparation(int separationId)
        {
           using (var context = _context) {
                var currentPromotion = new PromotionDTO();
                var response = new ResponsePayload<PromotionDTO>();
                var availablePromotion = await context.ClientSeparationProduct.FirstAsync(x => x.Id == separationId);
                if (availablePromotion.Promotion != null)
                {
                    currentPromotion.Id = availablePromotion.Promotion.Id;
                    currentPromotion.PromotionName = availablePromotion.Promotion.PromotionName;
                }
                else
                {
                    currentPromotion.Id = null;
                    currentPromotion.PromotionName = "This separation does not have a promotion";
                }
                response.Value = currentPromotion;
                response.Status = 200;

                return response;
           }
        }

        async Task<ResponsePayload<ClientDTO>> IClientRepository.GetClient(int clientId)
        {
            using(var context = _context)
            {
                var response = new ResponsePayload<ClientDTO>();
                var clientDTO = new ClientDTO();
                var client =await context.Client.FirstOrDefaultAsync(x => x.Id == clientId);
                if(client != null)
                {
                    clientDTO.Id = client.Id;
                    clientDTO.Name = client.Name;
                    response.Status = 200;
                }
                else
                {
                    response.Status = 404;
                    response.Message = "Client could not be found";
                }
                response.Value = clientDTO;
                return response;
            }
        }

        async Task<ResponsePayload<ClientProductPurchaseDTO>> IClientRepository.GetClientPurchaseProducts(int purchaseId)
        {
            using(var context = _context)
            {
                var response = new ResponsePayload<ClientProductPurchaseDTO>();
                var purchaseDTO = new ClientProductPurchaseDTO();
                var purchase = await context.ClientProductPurchase.FirstOrDefaultAsync(x => x.Id == purchaseId);
                if(purchase != null)
                {
                    purchaseDTO.Id = purchase.Id;
                    purchaseDTO.PurchaseDate = purchase.PurchaseDate;
                    purchaseDTO.ClientId = purchase.ClientId;
                    purchaseDTO.PurchaseDetails = purchase.ClientProductPurchaseDetails != null ? purchase.ClientProductPurchaseDetails.Select(y => new ClientProductPurchaseDetailDTO
                    {
                        ProductId = y.ProductId,
                        CurrentProductPrice = y.CurrentProductPrice,
                        QuantityPurchase = y.QuantityPurchase,
                        Id = y.Id,
                    }).ToList() : new List<ClientProductPurchaseDetailDTO>();
                    response.Status = 200;
                }
                else
                {
                    response.Status = 404;
                    response.Message = "Purchase could not be found";
                }
                response.Value = purchaseDTO;
                return response;
            }
        }
        async Task<List<ClientProductPurchaseDTO>> IClientRepository.GetAllClientPurchaseProducts(int clientId)
        {
            using(var context = _context)
            {
                var allClientPurchases = await context.ClientProductPurchase.Where(x => x.ClientId == clientId).Select(x => new ClientProductPurchaseDTO
                {
                    ClientId = x.ClientId,
                    Id = x.Id,
                    PurchaseDate = x.PurchaseDate,
                    PurchaseDetails = x.ClientProductPurchaseDetails != null ? x.ClientProductPurchaseDetails.Select(y => new ClientProductPurchaseDetailDTO
                    {
                        ProductId = y.ProductId,
                        CurrentProductPrice = y.CurrentProductPrice,
                        QuantityPurchase = y.QuantityPurchase,
                        Id = x.Id,
                    }).ToList() : new List<ClientProductPurchaseDetailDTO>()
                }).ToListAsync();
                return allClientPurchases;
            }
        }
        async Task<ResponsePayload> IClientRepository.PurchaseProduct(List<CreateEditClientProductPurchaseDetailDTO> clientProductPurchaseDetailDTOs, int clientId)
        {
            var response = new ResponsePayload();
            try
            {
                using (var context = _context)
                {
                    var isClientPreviouslyCreated = await context.Client.AnyAsync(x => x.Id == clientId);
                    if(!isClientPreviouslyCreated)
                    {
                        response.Status = 404;
                        throw new Exception("Client does not exists");
                    }
                    else
                    {
                        var purchaseList = new List<ClientProductPurchaseDetail>();
                        var purchase = new ClientProductPurchase
                        {
                            ClientId = clientId,
                            PurchaseDate = DateTime.Now,
                        };
                        foreach (var item in clientProductPurchaseDetailDTOs)
                        {
                            var isProductPreviouslyCreated = await context.Product.AnyAsync(x => x.Id == item.ProductId);
                            if (!isProductPreviouslyCreated)
                            {
                                response.Status = 404;
                                throw new Exception("Product does not exists");
                            }
                            else
                            {
                                var clientProductPurchaseDetailDTO = new ClientProductPurchaseDetail
                                {
                                    ProductId = item.ProductId.Value,
                                    QuantityPurchase = item.QuantityPurchase.Value,
                                    CurrentProductPrice = item.CurrentProductPrice,
                                    ClientProductPurchaseId = purchase.Id
                                };
                                purchaseList.Add(clientProductPurchaseDetailDTO);
                            }
                        }
                        purchase.ClientProductPurchaseDetails = purchaseList;
                        await context.AddAsync(purchase);
                        await context.SaveChangesAsync();
                        response.Status = 201;
                    }
                }
            }
            catch (Exception ex)
            {
                response.Status = response.Status != null ? response.Status : 500;
                response.Message = ex?.InnerException?.Message ?? ex.Message;
            }
            return response;
        }

        async Task<ResponsePayload> IClientRepository.SeparateProducts(List<CreateEditClientSeparationProductDetailDTO> clientSeparationProductDetailDTOs, int clientId)
        {
            var response = new ResponsePayload();
            try
            {
                using (var context = _context)
                {
                    var isClientPreviouslyCreated = await context.Client.AnyAsync(x => x.Id == clientId);
                    decimal total = 0;
                    if (!isClientPreviouslyCreated)
                    {
                        response.Status = 404;
                        throw new Exception("Client does not exists");
                    }
                    else
                    {
                        var separatedProductsList = new List<ClientSeparationProductDetail>();
                        var separation = new ClientSeparationProduct
                        {
                            ClientId = clientId,
                            CreatedDate = DateTime.Now,        
                        };
                        foreach (var item in clientSeparationProductDetailDTOs)
                        {
                            var productPreviouslyCreated = await context.Product.FirstOrDefaultAsync(x => x.Id == item.ProductId);
                            if (productPreviouslyCreated == null)
                            {
                                response.Status = 404;
                                throw new Exception("Product does not exists");
                            }
                            else
                            {
                                var clientseparationProductDTO = new ClientSeparationProductDetail
                                {
                                    ProductId = item.ProductId.Value,
                                    SeparatedQuantity = item.SeparatedQuantity.Value,
                                    
                                };
                                separatedProductsList.Add(clientseparationProductDTO);
                                total += productPreviouslyCreated.Price * clientseparationProductDTO.SeparatedQuantity;
                            }
                        }
                        var promo = await context.Promotion.FirstOrDefaultAsync(x => total > x.MinimalAmount && total < x.MaximalAmount);
                        if(promo != null)
                        {
                            separation.PromotionId = promo.Id;
                        }
                        separation.ClientSeparationProductDetails = separatedProductsList;
                        await context.AddAsync(separation);
                        await context.SaveChangesAsync();
                        response.Status = 201;
                    }
                }
            }
            catch (Exception ex)
            {
                response.Status = response.Status != null ? response.Status : 500;
                response.Message = ex?.InnerException?.Message ?? ex.Message;
            }
            return response;
        }
    }
}
