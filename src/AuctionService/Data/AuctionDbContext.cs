using AuctionService.Entities;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Data;

public class AuctionDbContext (DbContextOptions<AuctionDbContext> options):DbContext(options)
{
	public DbSet<Auction> Auctions {get; set;}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.AddInboxStateEntity();
		modelBuilder.AddOutboxMessageEntity();
		modelBuilder.AddOutboxStateEntity();
	}	
}
