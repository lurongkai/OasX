﻿using System.Data.Entity.ModelConfiguration;
using OasX.Domain.Application;

namespace OasX.Infrastructure.Mapping
{
    public class NewsMapping : EntityTypeConfiguration<News>
    {
        public NewsMapping() {
            HasKey(m => m.NewsId);

            Property(m => m.Title).IsRequired();
            Property(m => m.Content).IsRequired();
        }
    }
}