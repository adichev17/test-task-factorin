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
git clone https://github.com/adichev17/Test-Task-SendMailAndLogToDbMessag.git
```
* в файле appsettings.json в поле "FullPathFolder" указать полный путь к каталогу для отслеживания
* в файле appsettings.json в поле "OutputFilePathResult" указать полный путь к файлу (.txt) в который будет записан результат работы. Если по указанному пути файл не найден, то он будет создан автоматически (ex.: C:\\Users\\adichev\\folder\\result.txt)
```
cd src
cd FileFolderWatcher
dotnet run
```



