# Diferenças entre View, Table-Valued Function, Stored Procedure e Trigger

## View
Uma View é uma consulta salva no banco de dados que funciona como uma tabela virtual.

### Exemplo:
```sql
CREATE VIEW vw_ClientesAtivos AS
SELECT Id, Nome, Email
FROM Clientes
WHERE Ativo = 1;
```

---

## Table-Valued Function
É uma função que retorna uma tabela como resultado.

### Exemplo:
```sql
CREATE FUNCTION fn_PedidosPorCliente (@ClienteId INT)
RETURNS TABLE
AS
RETURN
(
    SELECT Id, ValorTotal, DataPedido
    FROM Pedidos
    WHERE ClienteId = @ClienteId
);
```

---

## Stored Procedure
É um conjunto de comandos SQL armazenados para executar operações específicas.

### Exemplo:
```sql
CREATE PROCEDURE sp_CadastrarCliente
    @Nome VARCHAR(100),
    @Email VARCHAR(100)
AS
BEGIN
    INSERT INTO Clientes (Nome, Email)
    VALUES (@Nome, @Email);
END;
```

---

## Trigger
Uma Trigger é executada automaticamente após eventos como INSERT, UPDATE ou DELETE.

### Exemplo:
```sql
CREATE TRIGGER trg_LogExclusaoCliente
ON Clientes
AFTER DELETE
AS
BEGIN
    INSERT INTO Logs (Mensagem)
    VALUES ('Cliente removido do sistema');
END;
```
