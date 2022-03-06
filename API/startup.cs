using AutoMapper;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddSingleton<LibraryContext>(_ =>
            new LibraryContext(Configuration.GetConnectionString("DefaultConnection")));

        services.AddSingleton<PujaContext>(_ =>
            new PujaContext(Configuration.GetConnectionString("DefaultConnection")));



        var mapperConfig = new MapperConfiguration(mc =>
        {
            // mc.AddProfile(new BookProfile());
            // mc.AddProfile(new FaltasProfile());
            mc.AddProfile(new RocaProfile());
            mc.AddProfile(new PujaProfile());
        });

        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);

        // services.AddSingleton<IBookService, BookService>();
        // services.AddSingleton<IFaltasService, FaltasService>();
        services.AddSingleton<IRocaService, RocaService>();
        services.AddSingleton<IPujaService, PujaService>();

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();

        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());


        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}