using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PartyInvites.Models;

namespace PartyInvites.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                    : base(options)
        { }
        //Taking the Internal Object and mapping it a Phyiscal (Singular) Table Oject
            public DbSet<GuestResponse> GuestResponse { get; set; }


    }
}