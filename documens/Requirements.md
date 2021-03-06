﻿# Требования к проекту

## 1 Введение

Сущесвует множество веб-проектов, которые позволяют прослушивать музыку, скачивать её, просматривать топы артистов, альбомов, треков. Хоть их и много, но большинство всё же пользуются популярностью. Основной целью является сделать удобное и качественное веб-приложение, не перегруженное информацией и позволяющее свободно разобраться в интерфейсе и структуре готового продукта. Также у данного проекта много пространства для дальнейшего совершенствования и развития.
Цель разработки - веб-приложение MusicCenter на платформе ASP.NET Core, которое будет предоставлять пользователю возможность:

* создавать список прослушенной им музыки, список избранной музыки, прлейлист музыки, которую пользователь хотел бы прослушать;

* отображать топ музыкальных произведений, авторов, альбомов; 

* искать и прослушивать музыку;

* быть в курсе новинок и трендов музыкальной индустрии.
## 2 Требования пользователя

### 2.1 Программные интерфейсы

База данных проекта и веб-хостинг будут расположены в сервисе Microsoft Azure.
Проект будет взаимодействовать с сервисом Last.fm для получения информации о музыке.

### 2.2 Интерфейс пользователя


Главная страница :

![](https://github.com/artiom0724/MusicCenter/blob/master/Mockups/Home.PNG?raw=true)


Страница авторизации:

![](https://github.com/artiom0724/MusicCenter/blob/master/Mockups/Sign%20in.PNG?raw=true)



Управление учетной записью:

![](https://github.com/artiom0724/MusicCenter/blob/master/Mockups/Account.PNG?raw=true)


Плейер для прослушивания:

![](https://github.com/artiom0724/MusicCenter/blob/master/Mockups/Player.PNG?raw=true)


Помощь, поддержка и контакты:

![](https://github.com/artiom0724/MusicCenter/blob/master/Mockups/Help.PNG?raw=true)


### 2.3 Характеристики пользователей


Целевая аудитория приложения - люди любого возраста, интересующиеся топовой музыкой, которые хотят быть в курсе трендов музыкальной индустрии, хотят иметь доступный и качественный веб-ресурс для прослушивания музыки. 


Минимальные необходимые навыки - умение пользоваться веб-браузером и музыкальной гарнитурой,также, желательно, социальными сетями.


### 2.4 Предположения и зависимости

Возможна неподдерживаемость используемых библиотек в некоторых старых браузерах, а также отличное отображение приложения от приведенных мокапов, зависящее от используемого пользователем браузера и разрешения монитора.
База Last.fm может содержать не все существующие музыкальны произведения или предоставлять их не в лучшем виде.

## 3 Системные требования

Для использования приложения нужен один из следующих браузеров:

* Chrome и другие браузеры основанные на Chromiuim

* Firefox

* Internet Explorer версии не ниже 10

* Microsoft Edge 

* Opera 

* Safari (только для Mac, версия для Windows не поддерживается)
 

### 3.1 Функциональные требования
 
3.1.1 Проигрывание треков(Плейер)

3.1.2 Поиск по жанру, исполнителю, альбому.

3.1.3 Запоминание последнего прослушанного трека, чтобы после авторизации можно было сразу в плейере(не искать неизввестно где) его прослушать.

3.1.4 Отправка треков в плейлист и автоматическое проигрывание в порядке очереди.

3.1.2 Авторизация:
1. Возможность авторизации с помощью одной из социальных сетей(VK,Google+,Twitter, Facebook). Пользователь будет переадресован на страницу подтвеждения авторизации при помощи выбранной социальной сети.
2. Авторизованным пользователям доступен профиль.

3.1.5 Редактирование профиля:
1. Сохраниение треков в "Favorites".
2. Автоматическое сохранние треков в "Listened".

### 3.2 Нефункциональные требования
 
#### 3.2.1 Атрибуты качества
  1. Не более 10-и сбоев доступа в сутки.
#### 3.2.2 Внешние интерфейсы
1. Приложение должно предоставлять информацию о максимально возможном числе музыкальных произведений, благодаря использованию api популярного веб-ресурса Last.fm.
2.Обеспечить запись в базу данных Microsoft SQL Server, расположенную в облачном сервисе Microsoft Azure.
3.Обеспечить взаимодействие с OAuth сервисом.