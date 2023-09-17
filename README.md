![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![MicrosoftSQLServer](https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white)

# Project Title

Выполнение тестового задания

## Description

Worker, задача которого обрабатывать и отслеживать появление новых файлов в заданном каталоге <br />
Выполнение тестового задания на sql располагается в sql-task.sql

Более подробно в файле .docx

## Stack

- .NET 7
- HtmlAgilityPack

## Getting Started

### Installing

```
git clone https://github.com/adichev17/test-task-factorin.git
```
* в файле appsettings.json в поле "FullPathFolder" указать полный путь к каталогу для отслеживания (ex.: C:\\\Users\\\adichev\\\folderForTrack)
* в файле appsettings.json в поле "OutputFilePathResult" указать полный путь к файлу (.txt) в который будет записан результат работы. Если по указанному пути файл не найден, то он будет создан автоматически (ex.: C:\\\Users\\\adichev\\\folder\\\result.txt)
```
cd src
cd FileFolderWatcher
dotnet run -c Release
```



