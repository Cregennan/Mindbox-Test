# Тахир Латыпов - Тестовое задание

## Задание 1

В рамках выполнения задания сделано: 
- Абстрактный класс `Shape` для вычисления площади фигур
- Классы `Circle` и `Square`
- Свойство `IsRight` для треугольника
- Юнит тесты с полным покрытием
  - Положительный радиус для круга
  - Положительные стороны треугольника, правило треугольника
  - Исключение при переполнении `double`

> "Вычисление площади фигуры без знания типа фигуры в compile-time"

**Как я понял требование:**<br/>
Свойство `Area` для получения площади фигуры реализовано в `Shape`.<br/>
Поэтому, мы всегда можем узнать площадь любой фигуры (наследника `Shape`) по этому свойству без знания конкретного типа.

## Задание 2

[Ссылка на файл с запросом SQL](https://vk.cc/cm3AUK)


<details>
<summary>Схема базы данных</summary>

![](https://sun9-76.userapi.com/impg/Ts3dGF60lHainhPy1UEytzSjKBkgswZ1VQn4DA/9Y9lMmdrEiI.jpg?size=516x250&quality=96&sign=07bc7caa4d3fff8a82d8aa66adaca2e6&type=album)

</details>

<details>
<summary>Запрос для генерации базы</summary>

```sql

CREATE TABLE Product (
    id int IDENTITY(1,1) PRIMARY KEY,
    name varchar(max)
);

CREATE TABLE Category(
    id int IDENTITY(1,1) PRIMARY KEY,
    name varchar(max)
);

CREATE TABLE ProductCategory(
    id int IDENTITY(1,1) PRIMARY KEY,
    product_id int FOREIGN KEY REFERENCES Product(id) ON DELETE CASCADE,
    category_id int FOREIGN KEY REFERENCES Category(id) ON DELETE CASCADE,
);

INSERT INTO Category (name)
VALUES (N'Одежда'),(N'Автомобили');

INSERT INTO Product (name)
VALUES (N'Куртка ''Asidak'''), (N'Ботинки'),
       (N'Lada 2112'), (N'Тушь');

INSERT INTO ProductCategory (product_id, category_id)
VALUES (1, 1), (2, 1), (3, 2);


```
</details>


### Пример результата выполнения

| ProductName | CategoryName | 
| --- | --- |
| Куртка 'Asidak' | Одежда | 
| Ботинки | Одежда | 
|Lada 2112| Автомобили|
| Тушь | `null` |


