using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IProductRepository
    {
        // Definir os contratos 
        // Com esses metodos posso permitir que minha camada de dominio possam ser acessadas sem dependencia de camda de infraestrutura.
        Task<IEnumerable<Product>> GetProductsAsync();
        // parametro int nullobol
        Task<Product> GetByIdAsync (int? id);
       //Task<Product> GetProductCategoryAsync(int? id);
        Task<Product> CreateAsync (Product product);
        Task<Product> UpdateAsync (Product product);
        Task<Product> RemoveAsync (Product product);

    }
}
