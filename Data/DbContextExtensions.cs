using System.Collections.Generic;
using System.Linq;
using AspVue.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace AspVue.Data
{
    public static class DbContextExtensions
    {
        public static UserManager<AppUser> UserManager { get; set; }
    
        public static void EnsureSeeded(this AppDbContext context)
        {
            if (UserManager.FindByEmailAsync("bleonard@acrtinc.com").GetAwaiter().GetResult() == null)
            {
                var user = new AppUser
                {
                    FirstName = "Bryan",
                    LastName = "Leonard",
                    UserName = "bleonard@acrtinc.com",
                    Email = "bleonard@acrtinc.com",
                    EmailConfirmed = true,
                    LockoutEnabled = false
                };

                UserManager.CreateAsync(user, "Password1*").GetAwaiter().GetResult();

                user = new AppUser
                {
                    FirstName = "Sarah",
                    LastName = "Ford",
                    UserName = "safford@acrtinc.com",
                    Email = "safford@acrtinc.com",
                    EmailConfirmed = true,
                    LockoutEnabled = false
                };

                UserManager.CreateAsync(user, "Password1*").GetAwaiter().GetResult();
            }

            AddProducts(context);
        }

        private static void AddProducts(AppDbContext context){
            if (context.Products.Any() == false){
                var products = new List<Product>(){
                    new Product {
                        Name = "Samsung Galaxy S8",
                        Slug = "samsung-galaxy-s8",
                        Thumbnail = "http://placehold.it/200x300",
                        ShortDescription = "Samsung Galaxy S8 Android smartphone with true edge to edge display",
                        Price = 499.99M,
                        Description = "Toam labore quaerat similique earum enim nesciunt expedita quod corporis itaque reiciendis? Aliquid iste maxime nostrum accusamus nisi, inventore non quam asperiores esse fugit voluptatum expedita molestias ratione unde explicabo vel beatae."

                    },
                    new Product {
                        Name = "iPhone Xs",
                        Slug = "iphone-x",
                        Thumbnail = "http://placehold.it/200x300",
                        ShortDescription = "Super Retina in two sizes — including the largest display ever on an iPhone.",
                        Price = 999.00M,
                        Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Perferendis tempora ad cum laudantium, omnis fugit amet iure quod dignissimos, voluptatem quasi? Nisi quaerat, fugit voluptas ducimus facilis impedit quod dicta, laborum sint iure nihil veniam aspernatur delectus officia culpa, at cupiditate? Totam minima ut deleniti laboriosam dolores cumque in, nesciunt optio! Quod recusandae voluptate facere pariatur soluta vel corrupti tenetur aut maiores, cumque mollitia fugiat illo tempore quibusdam laborum? Dicta aliquam libero, facere, maxime corporis qui officiis explicabo aspernatur non consequatur mollitia iure magnam odit enim. Eligendi suscipit, optio officiis repellat eos quis iure?"

                    },
                    new Product {
                        Name = "Pixel 3",
                        Slug = "pixel-3",
                        Thumbnail = "http://placehold.it/200x300",
                        ShortDescription = "Capture the perfect shot every time, get things done with the Google Assistant¹, enjoy an all-day battery, and more.",
                        Price = 799.00M,
                        Description = "Perferendis tempora ad cum laudantium, omnis fugit amet iure animi corporis labore repellat magnam perspiciatis explicabo maiores fuga provident a obcaecati tenetur nostrum, quidem quod dignissimos, voluptatem quasi? Nisi quaerat, fugit voluptas ducimus facilis impedit quod dicta, laborum sint iure nihil veniam aspernatur delectus officia culpa, at cupiditate? Totam minima ut deleniti laboriosam dolores cumque in, nesciunt optio! Quod recusandae voluptate facere pariatur soluta vel corrupti tenetur aut maiores, cumque mollitia fugiat laudantium error odit voluptas nobis laboriosam quo, rem deleniti? Iste quidem amet perferendis sed iusto consequatur mollitia iure magnam odit enim. Eligendi suscipit, optio officiis repellat eos quis iure? Omnis, error aliquid quibusdam iste amet nihil nisi cumque magni sequi enim illo autem nesciunt optio accusantium animi commodi tenetur neque eum vitae est."

                    },
                    new Product {
                        Name = "Moto G7",
                        Slug = "moto-g7",
                        Thumbnail = "http://placehold.it/200x300",
                        ShortDescription = "The new Moto G7 brings flagship features to a value-packed smartphone.",
                        Price = 249M,
                        Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Omnis, error aliquid quibusdam iste amet nihil nisi cumque magni sequi enim illo autem nesciunt optio accusantium animi commodi tenetur neque eum vitae est."

                    },
                    new Product {
                        Name = "LG G8 ThinQ",
                        Slug = "lg-g8-thinq",
                        Thumbnail = "http://placehold.it/200x300",
                        ShortDescription = "",
                        Price = 619.99M,
                        Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Cumque voluptatum quidem corporis? Fugiat ducimus incidunt veniam voluptate quibusdam dicta, voluptatibus suscipit autem totam quam eum unde saepe impedit aliquam libero!"
                    }
                };

                context.Products.AddRange(products);
                context.SaveChanges();
            }
        }
    }
}