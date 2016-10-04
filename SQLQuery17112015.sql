-- Andre Sombra
--Atualizado em 04/10/2016
--Atualizado no Desktop

select prc_credor as X_CREDOR from notaempenho where NOTAEMP=21030001 and ORGAO=07 and UNDORC=02

select (select prc_credor as X_CREDOR from notaempenho where NOTAEMP=PRC_NOTAEMP and ORGAO=PRC_ORGAO and UNDORC=PRC_UND_ORC)
,* from processos where prc_notaemp != 'EXTRA' and PRC_CREDOR is null

select * from PROCESSOS where PRC_DTREFDOC=012016 and prc_notaemp != 'EXTRA' and PRC_CREDOR is null

select * from NOTAEMPENHO --Teste comentario