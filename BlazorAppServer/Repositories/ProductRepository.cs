using Azure;
using BlazorAppServer.Interfaces;
using BlazorAppShared;
using BlazorAppShared.DTO;
using BlazorAppShared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppServer.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
                _context = context;
        }
        async Task<ResponsePayload<ProductDTO>> IProductRepository.CreateProduct(CreateUpdateProductDTO productDTO)
        {
            var response = new ResponsePayload<ProductDTO>();
            try
            {
                using (var context = _context)
                {
                    var allColorsFiltered = await context.Color.Where(x => productDTO.Colors.Select(x => x.ColorId).Contains(x.Id)).ToListAsync();
                    var product = new Product
                    {
                        Name = productDTO.Name,
                        Price = productDTO.Price.Value,
                        ProductColorDetails = allColorsFiltered != null ? allColorsFiltered.Select(x => new ProductColorDetail { ColorId = x.Id }).ToList() : new List<ProductColorDetail>(),
                        Quantity = productDTO.Quantity.Value,
                        CreatedDate = DateTime.Now,
                        SellDepartmentId = productDTO.SellDepartmentId.Value,
                    };
                    await context.AddAsync(product);
                    await context.SaveChangesAsync();
                    response.Status = 201;
                    response.Message = "Product was created";
                    var productToShow = new ProductDTO
                    {
                        ColorDTOs = product.ProductColorDetails.Select(x => new ColorDTO { Id = x.ColorId, Name = x.Color.Name }).ToList(),
                        Quantity = product.Quantity,
                        Name = product.Name,
                        Id = product.Id,
                        Price = product.Price,
                        SellDepartmentName = ""
                    };
                    response.Value = productToShow;
                }
            }
            catch (Exception ex)
            {
                response.Status = response.Status != null ? response.Status : 500;
                response.Message = ex?.InnerException?.Message ?? ex.Message;
            }
            return response;
        }

        async Task<ResponsePayload> IProductRepository.DeleteProduct(int productId)
        {
            var response = new ResponsePayload();
            try
            {
                using (var context = _context)
                {
                    var productPreviouslySaved = await context.Product.FirstOrDefaultAsync(x => x.Id == productId);
                    if (productPreviouslySaved != null)
                    {
                        context.ProductColorDetail.RemoveRange(productPreviouslySaved.ProductColorDetails.ToList());
                        context.Product.Remove(productPreviouslySaved);
                        await context.SaveChangesAsync();
                        response.Status = 200;
                        response.Message = "Product was deleted";
                    }
                    else
                    {
                        response.Status = 404;
                        throw new Exception("Product could not be found");
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

        async Task<List<ProductDTO>> IProductRepository.GetAllProducts()
        {
            using(var context = _context)
            {
                var response = new ResponsePayload<List<ProductDTO>>();
                var allProducts = await context.Product.Where(x => x.Quantity > 0 && x.ProductColorDetails.Count > 0).Select(x => new ProductDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price   = x.Price,
                    Quantity = x.Quantity,
                    SellDepartmentName = x.SellDepartment.Name,
                    SellDepartmentId = x.SellDepartmentId,
                    ColorDTOs = x.ProductColorDetails != null ? x.ProductColorDetails.Select(y => new ColorDTO { Id = y.Id, Name = y.Color.Name}).ToList() : new List<ColorDTO>()
                }).ToListAsync();
                response.Status = 200;
                return allProducts;
            }

        }

        async Task<ResponsePayload<ProductDTO>> IProductRepository.GetProductById(int productId)
        {
            using (var context = _context)
            {
                var response = new ResponsePayload<ProductDTO>();
                var product = await context.Product.FirstOrDefaultAsync(x => x.Id == productId);
                if(product != null)
                {
                    var productDTO = new ProductDTO
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Price = product.Price,
                        Quantity = product.Quantity,
                        SellDepartmentName = product.SellDepartment.Name,
                        SellDepartmentId = product.SellDepartmentId,
                        ColorDTOs = product.ProductColorDetails != null ? product.ProductColorDetails.Select(y => new ColorDTO { Id = y.ColorId, Name = y.Color.Name }).ToList() : new List<ColorDTO>()
                    };
                    response.Status = 200;
                    response.Value = productDTO;
                }
                else
                {
                    response.Status = 404;
                    response.Message = "Product could not be found";
                }
                return response;
            }
        }

        async Task<ResponsePayload<ProductDTO>> IProductRepository.UpdateProduct(CreateUpdateProductDTO productDTO, int productId)
        {
            var response = new ResponsePayload<ProductDTO>();
            try
            {
                using (var context = _context)
                {
                    var product = await context.Product.FirstOrDefaultAsync(x => x.Id == productId);
                    if (product != null)
                    {
                        var allColorsFiltered = await context.Color.Where(x => productDTO.Colors.Select(x => x.ColorId).Contains(x.Id)).ToListAsync();
                        product.Price = productDTO.Price.Value;
                        product.Quantity = productDTO.Quantity.Value;
                        product.Name = productDTO.Name;
                        product.SellDepartmentId = productDTO.SellDepartmentId.Value;
                        product.ProductColorDetails = product.ProductColorDetails != null ?  product.ProductColorDetails.Where( x => allColorsFiltered.Select( y => y.Id).Contains(x.ColorId)).ToList() : product.ProductColorDetails;
                        await context.SaveChangesAsync();
                        response.Status = 201;
                        response.Message = "Product was updated";
                        response.Value = new ProductDTO
                        {
                            ColorDTOs = product.ProductColorDetails.Select(x => new ColorDTO { Id = x.ColorId, Name = x.Color.Name }).ToList(),
                            Id = product.Id,
                            Name = product.Name,
                            Price = product.Price,
                            Quantity = product.Quantity,
                            SellDepartmentId = product.SellDepartmentId,
                            SellDepartmentName = product.SellDepartment.Name,
                        };
                    }
                    else
                    {
                        response.Status = 404;
                        response.Message = "Product could not be found";
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
