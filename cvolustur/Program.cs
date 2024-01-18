#nullable enable
using System;

class Person
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Contact { get; set; } = string.Empty;
    public Education? Education { get; set; }
    public WorkExperience? WorkExperience { get; set; }

    public string GenerateCV()
    {
        string cv = $"Name: {Name}\nAge: {Age}\nContact: {Contact}\n\n";

        if (Education != null)
        {
            cv += "Education:\n" + Education.DisplayDetails() + "\n\n";
        }

        if (WorkExperience != null)
        {
            cv += "Work Experience:\n" + WorkExperience.DisplayDetails() + "\n";
        }

        return cv;
    }
}

class Education
{
    public string Degree { get; set; } = string.Empty;
    public string Institution { get; set; } = string.Empty;
    public int Year { get; set; }

    public virtual string DisplayDetails()
    {
        return $"{Year} - {Degree} in {Institution}";
    }
}

class WorkExperience
{
    public string Title { get; set; } = string.Empty;
    public string Company { get; set; } = string.Empty;
    public int Year { get; set; }
    public string? Details { get; set; }

    public virtual string DisplayDetails()
    {
        if (string.IsNullOrEmpty(Details))
        {
            return $"{Year} - {Title} at {Company}";
        }
        else
        {
            return $"{Year} - {Title} at {Company} ({Details})";
        }
    }
}

class DetailedWorkExperience : WorkExperience
{
    public string? AdditionalDetails { get; set; }

    public override string DisplayDetails()
    {
        string baseDetails = base.DisplayDetails();
        return $"{baseDetails}\nAdditional Details: {AdditionalDetails ?? "N/A"}";
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Adınız: ");
        string name = Console.ReadLine() ?? string.Empty;

        Console.Write("Yaşınız: ");
        int age;

        while (!int.TryParse(Console.ReadLine(), out age))
        {
            Console.WriteLine("Hatalı giriş. Lütfen geçerli bir sayı girin.");
            Console.Write("Yaşınız: ");
        }

        Console.Write("İletişim Bilgisi: ");
        string contact = Console.ReadLine() ?? string.Empty;

        Console.Write("Eğitim Derecesi: ");
        string educationDegree = Console.ReadLine() ?? string.Empty;

        Console.Write("Eğitim Kurumu: ");
        string educationInstitution = Console.ReadLine() ?? string.Empty;

        Console.Write("Eğitim Yılı: ");
        int educationYear;

        while (!int.TryParse(Console.ReadLine(), out educationYear))
        {
            Console.WriteLine("Hatalı giriş. Lütfen geçerli bir sayı girin.");
            Console.Write("Eğitim Yılı: ");
        }

        Console.Write("İş Başlığı: ");
        string workTitle = Console.ReadLine() ?? string.Empty;

        Console.Write("İş Yeri: ");
        string workCompany = Console.ReadLine() ?? string.Empty;

        Console.Write("İş Yılı: ");
        int workYear;

        while (!int.TryParse(Console.ReadLine(), out workYear))
        {
            Console.WriteLine("Hatalı giriş. Lütfen geçerli bir sayı girin.");
            Console.Write("İş Yılı: ");
        }

        Console.Write("İş Detayları (isteğe bağlı): ");
        string workDetails = Console.ReadLine() ?? string.Empty;

        Console.Write("Ek İş Detayları (isteğe bağlı): ");
        string additionalDetails = Console.ReadLine() ?? string.Empty;

        Person person = new Person
        {
            Name = name,
            Age = age,
            Contact = contact,
            Education = new Education { Degree = educationDegree, Institution = educationInstitution, Year = educationYear },
            WorkExperience = new DetailedWorkExperience { Title = workTitle, Company = workCompany, Year = workYear, Details = workDetails, AdditionalDetails = additionalDetails }
        };

        string cv = person.GenerateCV();
        Console.WriteLine("\n--- Oluşturulan CV ---\n");
        Console.WriteLine(cv);
    }
}
