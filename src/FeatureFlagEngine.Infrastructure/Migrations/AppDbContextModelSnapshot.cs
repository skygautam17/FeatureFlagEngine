
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;

[DbContext(typeof(AppDbContext))]
partial class AppDbContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity("FeatureFlagEngine.Domain.Entities.FeatureFlag", b =>
        {
            b.Property<Guid>("Id");
            b.Property<string>("Key");
            b.Property<string>("Description");
            b.Property<bool>("Enabled");
            b.HasKey("Id");
            b.ToTable("FeatureFlags");
        });
    }
}
