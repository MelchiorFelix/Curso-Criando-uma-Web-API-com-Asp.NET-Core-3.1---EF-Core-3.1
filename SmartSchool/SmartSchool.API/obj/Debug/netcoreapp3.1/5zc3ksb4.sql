CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

CREATE TABLE "Alunos" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Alunos" PRIMARY KEY AUTOINCREMENT,
    "Nome" TEXT NULL,
    "Sobrenome" TEXT NULL,
    "Telefone" TEXT NULL
);

CREATE TABLE "Professores" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Professores" PRIMARY KEY AUTOINCREMENT,
    "Nome" TEXT NULL
);

CREATE TABLE "Disciplinas" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Disciplinas" PRIMARY KEY AUTOINCREMENT,
    "Nome" TEXT NULL,
    "ProfessorId" INTEGER NOT NULL,
    CONSTRAINT "FK_Disciplinas_Professores_ProfessorId" FOREIGN KEY ("ProfessorId") REFERENCES "Professores" ("Id") ON DELETE CASCADE
);

CREATE TABLE "AlunoDisciplinas" (
    "AlunoId" INTEGER NOT NULL,
    "DisciplinaId" INTEGER NOT NULL,
    CONSTRAINT "PK_AlunoDisciplinas" PRIMARY KEY ("AlunoId", "DisciplinaId"),
    CONSTRAINT "FK_AlunoDisciplinas_Alunos_AlunoId" FOREIGN KEY ("AlunoId") REFERENCES "Alunos" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_AlunoDisciplinas_Disciplinas_DisciplinaId" FOREIGN KEY ("DisciplinaId") REFERENCES "Disciplinas" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_AlunoDisciplinas_DisciplinaId" ON "AlunoDisciplinas" ("DisciplinaId");

CREATE INDEX "IX_Disciplinas_ProfessorId" ON "Disciplinas" ("ProfessorId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20200729115909_init', '3.1.0');

