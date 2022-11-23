namespace BlazorEcommerce.Server.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                 new Product
                 {
                     Id = 1,
                     Title = "Book 1",
                     Description = "A photo book or photobook is a book in which photographs make a significant contribution to the overall content. A photo book is related to and also often used as a coffee table book.",
                     ImageUrl = "https://plus.unsplash.com/premium_photo-1667251759217-45e2eec2e38e?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=387&q=80",
                     Price = 99.9m
                 },
            new Product
            {
                Id = 2,
                Title = "Book 2",
                ImageUrl = "https://images.unsplash.com/photo-1557752281-0dcc70763e98?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=580&q=80",
                Description = "A photo book or photobook is a book in which photographs make a significant contribution to the overall content. A photo book is related to and also often used as a coffee table book.",
                Price = 69.9m
            },
            new Product
            {
                Id = 3,
                Title = "Book 3",
                Description = "A photo book or photobook is a book in which photographs make a significant contribution to the overall content. A photo book is related to and also often used as a coffee table book.",
                ImageUrl = "https://media.istockphoto.com/id/653277816/vector/white-and-blue-modern-business-card-template.jpg?s=612x612&w=is&k=20&c=8kCG1Zl45xvEw1oBV_2-lB6TmF0-4tVy2JdDOy8K5kI=",
                Price = 99.9m
            }
                );
           
        }

        public DbSet<Product> Products { get; set; }
    }
}
