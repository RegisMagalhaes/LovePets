import { Component } from 'react';

class TiposEventos extends Component{
    constructor(props){
        super(props);
        this.state = {
            // nomeEstado : valorInicial
            listaTiposEventos : [],
            titulo : ''
        }
    }

    buscarTiposEventos = () => {
        console.log('agora vamos fazer a chamada para a API')

        // Faz a chamada para a API usando o fetch
        fetch('http://localhost:5000/api/tiposeventos')

        // Fetch retorna uma Promise que se resolve em uma resposta ( Response )
        // .then(resposta => console.log(resposta))

        // O método .json() retorna um objeto JavaScript
        // .then(resposta => console.log(resposta.json()))

        // Em outras palavras, define o tipo do dado do retorno da requisição (JSON)
        .then(resposta => resposta.json())
        
        // e atualiza o state listaTiposEventos com os dados obtidos
        // .then(data => console.log(data))
        .then(data => this.setState({ listaTiposEventos : data }))

        // Caso ocorra algum erro, mostra no console do navegador
        .catch( erro => console.log(erro) )
    }

    // Atualiza o state titulo com o valor do input
    atualizaEstadoTitulo = async (evento) => {
                        //  NomeState     Valor do input
        await this.setState({ titulo : evento.target.value })
        console.log(this.state.titulo)
    };

    // Função responsável por cadastrar um Tipo de Evento
    cadastrarTipoEvento = (event) => {
        // Ignora o comportamento padrão do navegador
        event.preventDefault();

        // Faz a chamada para a API usando Fetch
        fetch('http://localhost:5000/api/tiposeventos', {
            // Define o método (verbo) da requisição (POST)
            method : 'POST',

            // Define o corpo da requisição especificando o tipo (JSON)
            // em outras palavras, converte o state para uma string JSON
            body : JSON.stringify( { tituloTipoEvento : this.state.titulo } ),

            // Define o cabeçalho da requisição
            headers : {
                "Content-Type" : "application/json"
            }
        })

        // Exibe no console do navegador a mensagem "Tipo de Evento cadastrado!"
        .then(console.log("Tipo de Evento cadastrado!"))

        // Caso ocorra algum erro, 
        // exibe este erro no console do navegador
        .catch(error => console.log(error))

        // Então, atualiza a lista de Tipos de Eventos
        // sem o usuário precisar exexcutar qualquer ação
        .then(this.buscarTiposEventos)
    }

    // Chama a função buscarTiposEventos assim que o componente é renderizado
    componentDidMount(){
        this.buscarTiposEventos();
    }

    render(){
        return(
            <div>
                <main>
                    <section>
                        {/* Lista de tipos eventos */}
                        <h2>Lista de tipos eventos</h2>
                        <table>
                            <thead>
                                <tr>
                                    <th>#</th>{/* IDs */}
                                    <th>Título</th>{/* Títulos */}
                                </tr>
                            </thead>
                                
                            <tbody>
                                {
                                    //          Array
                                    this.state.listaTiposEventos.map( (tipoEvento) => {
                                        return (
                                            <tr key={tipoEvento.idTipoEvento}>
                                                <td>{tipoEvento.idTipoEvento}</td>
                                                <td>{tipoEvento.tituloTipoEvento}</td>
                                            </tr>
                                        )
                                    } )
                                }
                            </tbody>
                        </table>
                    </section>

                    <section>
                        {/* Cadastro de Tipos de Eventos */}
                        <h2>Cadastro de Tipo de Evento</h2>
                        
                        {/* Formulário de cadastro de Tipo de Evento */}
                        <form onSubmit={this.cadastrarTipoEvento}>
                            <div>
                                <input
                                    type="text"
                                    value={this.state.titulo}
                                    onChange={this.atualizaEstadoTitulo}
                                    placeholder="Título do Tipo de Evento"
                                />

                                <button type="submit">Cadastrar</button>
                            </div>
                        </form>
                    </section>
                </main>
            </div>
        );
    }
}

export default TiposEventos;