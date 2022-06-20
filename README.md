# GoodsCatalog

  

### Контекст

GoogsCatalog є навчальним додатком WPF, у ньому є каталог товарів з якого можна дізнаватися інформацію про товари різних категорій та брендів.
У якості архітектурного патерну використовується MVVM, для управління доступом до бази даних використовується mini ORM Dapper.
  

Потенційно може використовуватися у якості Desktop-застосунку онлайн-магазину, що дозволяє отримувати ту ж інформацію та функціональність, що й Web-застосунок цього магазину, компанії тощо.

  

### Функціональність

Застосунок дозволяє:

+ Керувати категоріями товарів

    + Додавати нові категорії

    + Редагувати існуючі категорії

    + Видаляти категорії

+ Керувати товарами

    + Додавати нові товари

    + Редагувати існуючі товари

    + Видаляти товари

+ Отримувати список товарів обраної категорії (наприклад одяг, взуття, аксусеари)

+ Отримувати список товарів обраного бренду

+ Отримувати список товарів, одночасно обравши потрібну категорію та бренд

+ Отримувати повну інформацію про обраний товар

    + Назва

    + Фото

    + Бренд

    + Розмір

    + Колір

    + Матеріал

    + Ціна

    + Опис товару

  

### Локальний запуск

Щоб локально запустити застосунок, потрібно перейти до Releases, обрати останній Release та завантажити Source code.

  

Розархівувавши .zip-файл з кодом, запустити проект можна двома шляхами:

+ Запустити існуючий файл застосунку GoogsCatalog.exe.

+ Згенерувати свій .exe файл, відкривши проект у Visual Studio за допомогою .sln-файлу та запустивши нову збірку проекту.

  

### Приклади використання

Запустивши застоcунок, можна побачити усі товари, які наразі є серед асортименту, та інформацію про них. Натиснувши на будь-який товар, можна отримати його фото, опис товару та бренд.

  

*Приклад отримання інформації про товар:*

![изображение](https://user-images.githubusercontent.com/71709401/174478465-8f681d0c-0515-446f-a89a-16b4872a5514.png)

***

У вкладці "Категорії" можна обрати бажану категорії товарів, після чого список товарів оновиться відповідно до обраної категорії.

  

*Приклад використання вкладки "Категорії":*

![изображение](https://user-images.githubusercontent.com/71709401/174478470-d7af234c-8133-4150-b5a4-20f1658eaafa.png)

***

Одночасно можно обрати бажану категорію та бренд товари, після чого список товарів оновиться, відображаючи лише товари обраної категорії бажаного бренду.

  

*Приклад використання вкладок "Категорії" та "Тренди" одночасно:*

![изображение](https://user-images.githubusercontent.com/71709401/174478475-0a54c914-9db5-4478-9051-3825f33a7486.png)

***

За допомогою налаштувань "Управління товарами" можна додавати нові товари та видаляти або редагувати існуючі товари.

  

*Існуючі функції у налаштуваннях "Управління товарами":*

![изображение](https://user-images.githubusercontent.com/71709401/174478479-88ec06cf-f574-49f3-99a4-62c9482d991c.png)

***

За допомогою налаштувань "Управління категоріями" можна додавати нові категорії та видаляти або редагувати існуючі категорії.

  

*Існуючі функції у налаштуваннях "Управління категоріями":*

![изображение](https://user-images.githubusercontent.com/71709401/174478484-24d86e96-9450-4624-87e4-24f2b020c861.png)

  

### Автор

  

**Іонова Юлія**  

LinkedIn: [Julia Ionova](https://www.linkedin.com/in/julia-ionova-1297aa196/)  

Telegram: [@julia_io](https://t.me/julia_io)  

Email: [juliaionova111@gmail.com](mailto:juliaionova111@gmail.com)
