Copyright 2017 (C) Xeno Innovations, Inc.
_Created by Damian J. Suess_

SQLite Admin is intended to be a lightweight IDE for SQLite databases with the ability to manage DB's _tables, edit views, merge DBs, encrypt (ADO.NET), etc._ . This is a complete rework of XI's internal project started back on 2011-06-17.

### Project Status
Currently a work in progress to provide a simple SQLite management studio.


## Milestones

### 1: Basic editor
Single database instance SQL syntax editor with executions. Start with SQLite engine, System.Data.Sqlite.

### 2: Object Explorer
Simple DB object explorer to display: tables, views, etc.

### 3: Solutions
Save project as solutions to be more IDE like.


### Ungroomed Features
* **Multi-DB Management** - Ability to manage multiple database connections in a single project
* **Selectable Engines** - Ability to choose which SQLite engine to execute from
* **Multi-platform** - Rework core system to be Mono compliant and run on multiple platforms.