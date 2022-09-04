using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

/// <summary>
/// Модель файлового каталога
/// </summary>
[EntityLabel("Файловый каталог")]
[SystemEntity()]
public class FileCatalog : HierDictionaryTable<FileCatalog>
{

    public virtual List<FileResource> Files { get; set; }

    public FileCatalog()
    {
        Files = new List<FileResource>();
    }

    public FileCatalog(string name)
    {
        Files = new List<FileResource>();
        Name = name;
    }



    
}
