using ModernStore.Domain.CommandHandlers;
using ModernStore.Domain.Commands;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace ModernStore.ConsoleDebug
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = new RegisterOrderCommand
            {
                Customer = Guid.NewGuid(),
                DeliveryFee = 9,
                Discount = 30,
                Items = new List<RegisterOrderItemCommand> {
                    new RegisterOrderItemCommand {
                        Product = Guid.NewGuid(),
                        Quantity =3
                    }
                }
            };

            GenerateOrder(
                    new FakeCustomerRepository(), 
                    new FakeProductRepository(), 
                    new FakeOrderRepository(),
                    command);
            Console.ReadKey();
        }

        public static void GenerateOrder(
            ICustomerRepository customerRepository,
            IProductRepository productRepository,
            IOrderRepository orderRepository,
            RegisterOrderCommand command)
        {
            var handler = new CustomerCommandHandler(customerRepository,productRepository,orderRepository);
            handler.Handler(command);

            if (handler.IsValid())
                Console.WriteLine("Pedido Cadastrado com Sucesso!");
        }
        public class FakeOrderRepository : IOrderRepository
        {
            public void Save(Order order)
            {                
            }
        }

        public class FakeProductRepository : IProductRepository
        {
            public Product Get(Guid id)
            {
            return new Product("Mouse", 299, "mouse.jpg", 20);
            }
        }
        public class FakeCustomerRepository : ICustomerRepository
        {
            public Customer Get(Guid Id)
            {
                return null;
            }

            public Customer GetByUserId(Guid Id)
            {
                return new Customer(
                     new Name("Marcelo", "Pereira da Silva")
                     , new Email("teste@gmail.com")
                     , new Document("32344243242")
                     , new User("marcelo", "1234")
                    );
            }
        }
    }
}
