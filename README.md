# vetislog
Модуль  тестирования доступности  vetis.api 



Модуль представляет собой утилиту, которая должна быть запущена
регулярно  - 1 раз в минуту  через планировщик заданий windows.
С документацией по планировщику задач можно ознакомиться 
по следующей ссылке:

https://technet.microsoft.com/ru-ru/library/cc748993(v=ws.11).aspx

Подробнее 
https://www.osp.ru/winitpro/2012/08/13033295/


Cоздание задания с помощью командной строки

Откройте окно командной строки. Для этого в меню Пуск последовательно выберите пункты Все программы, Стандартные и Командная строка.

Введите команду:

        schtasks /Create [/S <system> [/U <username> [/P [<password>]]]]
        [/RU <username> [/RP <password>]] /SC <schedule> [/MO <modifier>] [/D <day>]
        [/M <months>] [/I <idletime>] /TN <taskname> /TR <taskrun> [/ST <starttime>]
        [/RI <interval>] [ {/ET <endtime> | /DU <duration>} [/K] [/XML <xmlfile>] [/V1]]
        [/SD <startdate>] [/ED <enddate>] [/IT] [/Z] [/F]

Чтобы просмотреть справку для этой команды, введите:

schtasks /Create /?

