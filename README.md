# Vinil-Ecommerce Api
Projeto responsável por alimentar uma tabela de álbums com base na Api do Spotify e disponibilizar métodos para consultas e venda de álbums(discos) retornando cashback.

### Execução:
Para executá-lo, basta cloná-lo a um diretório em sua máquina utilizando o Visual Studio.
Por se tratar de uma Api, foi-se utilizado o Swagger para falicitar a visualização e execução dos métodos, além de mantê-los documentados.

### Métodos:

| Método | Descrição |
| ------ | ------ |
| UpdateTableSpotify | Responsável por atualizar a tabela de álbums(spotify) de acordo com a requisição feita, exemplo: "pop". |
| GetDisksByGenre | Responsável por obter discos por gênero musical, exemplo: "pop". O retorno desse método é paginado de acordo com a requisição (Página e Quantidade de Registros). |
| GetDisksById | Responsável por obter discos pelo seu identificador. |
| GetSalesByDate | Responsável por obter vendas dentro de um range de datas. O retorno desse método é paginado de acordo com a requisição (Página e Quantidade de Registros). |
| GetSalesById | Responsável por obter discos pelo seu identificador. |
| SellDisks | Responsável por efetuar vendas atráves dos identificadores dos discos, armazenando o cashback de acordo com o gênero musical e dia da semana. |

### Autor:
João Mateus Moreto