using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : Entity
    {
        //Usar private em set, garante que seus valores não serão alterardos externamente
        //public int Id { get; private set; }  - Herdando da classe entity, não preciso definir o id
        public string Name { get; private set; }

        //Construtor categorizado.
        public Category(string name)
        {
            ValidateDomain(name);
        }
        // Definir validações
        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(name);
           
        }

        // Permitir a atualização dos valores
        public void Update(string name)
        {
            ValidateDomain(name);
        }

        // Categoria terá um ou mais produtos então usarei uma classe ICollection
        // Uma categoria terá uma coleção de produtos
        public ICollection<Product> Products { get; set; }

        private void ValidateDomain(string name)
        {
            // Não validar quando o nome for nulo
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required");

            //  não validar quando  o nome for menor que 3.
            DomainExceptionValidation.When(name.Length < 3,
                "Name too short, minimum 3 characters");

            // Se não ocorrer nenhuma exceção, aí pode ser atribuido um valor
            Name = name;
        }
    }

}
