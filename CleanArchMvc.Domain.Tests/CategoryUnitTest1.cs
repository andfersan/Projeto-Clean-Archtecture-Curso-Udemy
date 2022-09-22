using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName ="Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        { // Quando la�ar este teste, n�o dever� lan�ar uma exce��o no dominio.
            Action action = () =>  new Category(1, "Category Name");
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        { 
            // Passando como parametro um id negativo invalidando o id.
            Action action = () => new Category(-1, "Category Name");
            action.Should()
                // Dever� lan�ar domain exception validation com a mensagem valor de id invalido
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }

        [Fact]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            // Passando como parametro apenas dois caracteres.
            Action action = () => new Category(1, "Ca");
            action.Should()
                // Dever� lan�ar domain exception validation com a mensagem valor de id invalido
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Name too short, minimum 3 characters");
        }

        [Fact]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            //Passando como parametro nome vazio.
            Action action = () => new Category(1, "");
            action.Should()
                // Dever� lan�ar domain exception validation nome n�o pode ser vazio.
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            //Passando como parametro valor nullo em string.
            Action action = () => new Category(1, null);
            action.Should()
                // Dever� lan�ar domain exception validation paramatro n�o pode ser nulo.
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
                
        }
    }
}
