Поменять название сервера в appsettings.json.
Создать БД с помощью миграций. Консоль диспетчера пакетов, проект по умолчанию DAL.Создаём миграции и обновляем БД.
При запуске API необходимо получить токен с GetToken (приходит в ответе ). Далее вставляем его в поле для авторизации в таком виде Bearer ваш токен.
Сначала нужно создать Person, а после этого создавать Speaker и Organizer.
Для создания Event необходимо указывать существующие Id в БД Place, Speaker, Organizer.
