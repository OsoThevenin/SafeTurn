

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafeTurn.Domain.Turns;

namespace SafeTurn.Persistence.Turns
{
    public class TurnConfiguration : IEntityTypeConfiguration<Turn>
    {
        public void Configure(EntityTypeBuilder<Turn> builder)
        {
        }
    }
}
