# OnlineShop.Api


## Online Shop CRM: Mahsulot Harid va Boshqaruv Tizimi


 Bu loyiha onlayn do'kon uchun CRM (mijozlar munosabatlari boshqarish tizimi) va veb-saytning bir qator komponentlarini o'z ichiga oladi. Bu CRM tizimi API, MVC va WinForms shakllarida ishlaydi. Mahsulot harid qilish vazifasini veb-sayt (MVC) bajaradi, bu erda mijozlar tomonidan mahsulotlar tanlash, harid qilish va to'lov amalga oshirishlari amalga oshiriladi. Boshqa tomonidan, administartorlar va do'kon egasi tomonidan mahsulotlar, buyurtmalar va mijozlar haqida ma'lumotlarni boshqarish uchun WinForms ilovasi (admin pane'l) ishlatiladi. Bu tizim foydalanuvchilar uchun qulay, samarali va maqbul do'kon tizimi tuzishda yordam beradi



### API da ishlatilgan Nuget package-lar


> Microsoft.entityframeworkcore 8.0.1


> Microsoft.entityframeworkcore.Design 8.0.1


> Microsoft.entityframeworkcore.Tools 8.0.1


> Microsoft.entityframeworkcore.SqlServer 8.0.1


> AutoMapper.Extensions.Microsoft.DependencyInjection 12.0.1


> AutoMapper 12.0.1


> Swashbuckle.AspNetCore 6.0.4

### OnlineShop clone qilib olish uchun [foziljonov7/OnlineShop](https://github.com/foziljonov7/OnlineShop.git) dan foydalaning.

Loyihani clone qilib olgach:

1. AppSettings.json faylida o'z ConnectionString ningizni kiriting:

```json
"ConnectionStrings": {
  "localhost": "your_connection_string_here"
}
```


## 2. Powershell da ushbu buyruqlarni amalga oshiring

- loyihadagi package larni qayta ishga tushuradi

```
dotnet restore
```

- loyihadagi xato va kamchiliklarni tekshiradi

```
dotnet test
```

- loyiha ishga tushurib beradi

```
dotnet build
```

- database update ni amalga oshiradi

```
dotnet ef database update
```


-  Loyihani ishga tushuring.

```
dotnet run
```


### [foziljonov7/OnlineShop](https://github.com/foziljonov7/OnlineShop)
### Loyiha muallifi: Abdulvosid Foziljonov
