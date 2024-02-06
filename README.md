# OnlineShop.Api

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
