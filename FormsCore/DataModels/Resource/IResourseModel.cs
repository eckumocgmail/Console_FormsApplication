using ApplicationDb.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IResourseModel
{    
    public DbSet<FileCatalog> FileCatalogs { get; set; }
    public DbSet<FileResource> FilResources { get; set; }
    public DbSet<ImageResource> Photos { get; set; }
    public DbSet<Resource> Resources { get; set; }
}