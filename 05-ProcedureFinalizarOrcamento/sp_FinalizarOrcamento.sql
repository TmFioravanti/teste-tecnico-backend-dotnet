CREATE PROCEDURE sp_FinalizarOrcamento
    @OrcamentoId INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ValorTotal DECIMAL(18,2);

    IF NOT EXISTS (
        SELECT 1
        FROM Orcamento
        WHERE Id = @OrcamentoId
    )
    BEGIN
        SELECT 'Orçamento não encontrado.' AS Mensagem;
        RETURN;
    END;

    IF NOT EXISTS (
        SELECT 1
        FROM Orcamento
        WHERE Id = @OrcamentoId
          AND Status = 'Aberto'
    )
    BEGIN
        SELECT 'O orçamento já foi finalizado ou possui outro status.' AS Mensagem;
        RETURN;
    END;

    IF NOT EXISTS (
        SELECT 1
        FROM OrcamentoItem
        WHERE OrcamentoId = @OrcamentoId
    )
    BEGIN
        SELECT 'O orçamento não possui itens.' AS Mensagem;
        RETURN;
    END;

    SELECT
        @ValorTotal = SUM(Quantidade * ValorUnitario)
    FROM OrcamentoItem
    WHERE OrcamentoId = @OrcamentoId;

    UPDATE Orcamento
    SET
        ValorTotal = @ValorTotal,
        Status = 'Finalizado',
        DataFinalizacao = GETDATE()
    WHERE Id = @OrcamentoId;

    SELECT 'Orçamento finalizado com sucesso.' AS Mensagem;
END;
