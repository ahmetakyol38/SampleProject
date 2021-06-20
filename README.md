# SampleProject
ASP.Net MVC Web UI, Asp.Net Web API, Unit Testler, DataAccess ve Business katmanlarıyla örnek bir proje olarak oluşturulmuştur.
API ve web arayüzünden ürün ekleme ve listeleme işlemleri yapar. 

- Web Arayüz Projesi : SampleProject.WebUI
- Web API Projesi : SampleProject.WebApi


# Kullanım
## 1. Database Oluşturma
SQL Server ortamında "SampleProject" isminde bir veritabanı oluşturunuz.
Proje için gereken tek tablonun oluşturma script'i aşağıdaki gibidir. 

```
USE [SampleProject]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Price] [money] NOT NULL,
	[UnitsInStock] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

```

## 2. Connection String Düzenlemeleri
- SampleProject.DataAccess.Tests projesi altında "App.Config"
- SampleProject.WebUI projesi altında "Web.Config"
- SampleProject.WebApi projesi altında "Web.Config"

dosyalarında connection string ayarını kendi bağlantınıza göre değiştiriniz.
```
<connectionStrings>
    <add name="SampleProjectContext" connectionString="{{Düzenlenecek Alan}}" providerName="System.Data.SqlClient" />
</connectionStrings>
```

Örnek;
```
<connectionStrings>
    <add name="SampleProjectContext" connectionString="Data Source=.;Initial Catalog=SampleProject;Integrated Security=True" providerName="System.Data.SqlClient" />
</connectionStrings>
```

## 3. Web UI kullanımı
"SampleProject.WebUI" projesinden başlattığınızda ürün listesi ekranı açılacaktır. Yeni ürün ekleme linklerini takip ederek kayıt işlemi yapabilirsiniz.

## 4. Web API projesi kullanımı
"SampleProject.WebApi" projesinden başlattığınızda "http://localhost:***/swagger/ui/index" linkini takip web ederek API dokümantasyonuna ulaşabilirsiniz.

Listeleme İşlemi;
```
[GET] http://localhost:***/api/products
```

Ekleme İşlemi;
```
[POST] http://localhost:***/api/products

{
    "Name": "Samsung Smart Led TV",
    "Price": "1450.0000",
    "UnitsInStock": "10"
}

```
