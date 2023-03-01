# Meeting scheduler

[![NPM](https://img.shields.io/npm/l/react)](https://github.com/LucasKalil-Programador/MeetingScheduler/blob/c7738c7ee1581e731cb8a860244a955e80c416cb/licence)

Este projeto pretende principal criar uma plataforma de agendamento de reuniões, onde o usuário poderá se cadastrar e agendar compromissos. Além disso, será possível obter uma agenda completa com todos os compromissos deste usuário.

## Banco de dados

Para o banco de dados foi escolhido o [MYSQL.](https://www.mysql.com/)

### Diagrama do banco de dados

#### [Código completo SQL](https://github.com/LucasKalil-Programador/MeetingScheduler/blob/c7738c7ee1581e731cb8a860244a955e80c416cb/MeetingScheduler/DataBase/Mysql_script.sql)

![Diagrama exemplo](https://user-images.githubusercontent.com/82661706/221879332-1115dbbb-1820-447a-9ef6-5fea5478f6bd.png)

#### Como é salvo as senhas dos usuários

O campo password salva a senha em uma versão sha256 isso adiciona segurança ao sistema, basicamente o sha256 criar uma camada de criptografia a senha.

![Select * from client;](https://user-images.githubusercontent.com/82661706/221879341-8bf1ad83-9e22-4c3d-8919-967fd619b59d.png)

### Padrão do projeto

Um dos padrões de projetos adotados para esse projeto foi o de factory cada objeto tem uma classe e um factory onde tem a função ajudar a criação desse objeto.

#### Classe client

![Classe client](https://user-images.githubusercontent.com/82661706/221879351-30b3aaf4-bd3f-4554-b780-a29357bc0b7e.png)

#### Classe que constrói um cliente

![Classe client factory](https://user-images.githubusercontent.com/82661706/221879347-887341d9-5aaa-4f45-b1aa-fe30138cbd89.png)

## Design do front-end

![Tela de login](https://user-images.githubusercontent.com/82661706/221879336-fb939195-7d78-4b36-ad50-41f84990e3fc.png)

![Tela de adição de participante](https://user-images.githubusercontent.com/82661706/221879339-bb9daa3a-e4c1-4a96-a6b3-966ae0941c7b.png)

![Agenda diária do usuário](https://user-images.githubusercontent.com/82661706/221879315-d23d927f-94a5-4fb4-9b06-9c55e847b1d8.png)

# Outras informações

Criador: Lucas Guimarães Kalil - desenvolvedor full stack

Linkedin: https://www.linkedin.com/in/lucas-kalil-436a6220a/<br>
Contato: lucas.prokalil2020@outlook.com
