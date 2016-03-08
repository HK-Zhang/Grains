using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace CSDemo
{
    class AutoMapperDemo
    {
        public void RunDemo()
        {
            //Fun1();
            //Fun2();
            //Fun3();
            //Fun4();
            Fun5();
        }

        private void Fun1()
        {
            Mapper.CreateMap<AddressDto, Address>();  

            AddressDto dto = new AddressDto
            {
                Country = "China",
                City = "Beijing",
                Street = "Dongzhimen Street",
                PostCode = "100001"
            };
            Address address = Mapper.Map<AddressDto, Address>(dto);
            Console.WriteLine("Country:{0},City:{1},Street:{2},PostCode:{3}", address.Country, address.City, address.Street, address.PostCode);
        }

        private void Fun2()
        {
            Mapper.CreateMap<AddressDto, Address>();  
            Address address = Mapper.Map<AddressDto, Address>(new AddressDto
                                                      {
                                                          Country = "China"
                                                      });
            if (string.IsNullOrEmpty(address.City))
            {
                Console.WriteLine("City is empty");
            }

        }

        private void Fun3()
        {
            Address address = Mapper.Map<AddressDto, Address>(null);
            if (address == null)
            {
                Console.WriteLine("address is empty");
            }

        }

        private void Fun4()
        {
            IMappingExpression<BookDto, Book> expression = Mapper.CreateMap<BookDto, Book>();
            Mapper.CreateMap<AddressDto, Address>();
            Mapper.CreateMap<BookStoreDto, BookStore>();

            BookStoreDto dto = new BookStoreDto
                       {
                           Name = "My Store",
                           Address = new AddressDto
                                         {
                                             City = "Beijing"
                                         },
                           Books = new List<BookDto>  
                                       {  
                                           new BookDto {Title = "RESTful Web Service"},  
                                          new BookDto {Title = "Ruby for Rails"},  
                                      }
                       };

            BookStore bookStore = Mapper.Map<BookStoreDto, BookStore>(dto);

            Console.WriteLine(bookStore.Books.First().Title);
        }

        private void Fun5()
        {
            //var map = Mapper.CreateMap<AddressDto, Address>();
            //map.ForMember(d => d.Country, opt => opt.MapFrom(s => s.CountryName));  


            var map = Mapper.CreateMap<BookDto, ContactInfo>();
            map.ConstructUsing(s => new ContactInfo
                                                      {
                                                          Blog = s.FirstAuthorBlog,
                                                          Email = s.FirstAuthorEmail,
                                                          Twitter = s.FirstAuthorTwitter
                                                      });

            BookDto dto = new BookDto
                       {
                           FirstAuthorEmail = "matt.rogen@abc.com",
                           FirstAuthorBlog = "matt.amazon.com",
                       };
            ContactInfo contactInfo = Mapper.Map<BookDto, ContactInfo>(dto);

            Console.WriteLine(contactInfo.Blog);

        }
    }

    public class BookStore
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; }
        public Address Address { get; set; }
    }

    public class Address
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public decimal Price { get; set; }
        public List<Author> Authors { get; set; }
        public DateTime? PublishDate { get; set; }
        public Publisher Publisher { get; set; }
        public int? Paperback { get; set; }
    }

    public class Publisher
    {
        public string Name { get; set; }
    }

    public class Author
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ContactInfo ContactInfo { get; set; }
    }

    public class ContactInfo
    {
        public string Email { get; set; }
        public string Blog { get; set; }
        public string Twitter { get; set; }
    }

    public class BookStoreDto
    {
        public string Name { get; set; }
        public List<BookDto> Books { get; set; }
        public AddressDto Address { get; set; }
    }

    public class AddressDto
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
    }

    public class BookDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public decimal Price { get; set; }
        public DateTime? PublishDate { get; set; }
        public string Publisher { get; set; }
        public int? Paperback { get; set; }
        public string FirstAuthorName { get; set; }
        public string FirstAuthorDescription { get; set; }
        public string FirstAuthorEmail { get; set; }
        public string FirstAuthorBlog { get; set; }
        public string FirstAuthorTwitter { get; set; }
        public string SecondAuthorName { get; set; }
        public string SecondAuthorDescription { get; set; }
        public string SecondAuthorEmail { get; set; }
        public string SecondAuthorBlog { get; set; }
        public string SecondAuthorTwitter { get; set; }
    }



}
