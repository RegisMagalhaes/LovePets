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
        // Em outras palavras, define o tipo de dado do retorno da requisição (JSON)
        .then(resposta => resposta.json())
        // .then(resposta => console.log(resposta.json()))

        // e atualiza o state listaTiposEventos com os dados obtidos
        .then(dados => this.setState({ listaTiposEventos : dados }))
        // .then(dados => console.log(dados))

        // Caso ocorra algum erro, mostra no console do navegador
        .catch(erro => console.log(erro))
    }

    // Atualiza o state titulo com o valor do input
    atualizaEstadoTitulo = async (event) => {
        //         NomeEstado  :     ValorInput
        await this.setState({ titulo : event.target.value })
        console.log(this.state.titulo)
    }

    // Função responsável por cadastrar um tipo de evento
    cadastrarTipoEvento = (event) => {
        // Ignora o comportamento padrão do navegador
        event.preventDefault();

        // Faz a chamada para a API usando fetch
        fetch('http://localhost:5000/api/tiposeventos', {
            // Define o método da requisição (POST)
            method : 'POST',

            // Define o corpo da requisição especificando o tipo (JSON)
            // Em outras palavras, converte o state para uma string JSON
            body : JSON.stringify( { tituloTipoEvento : this.state.titulo } ),

            // Define o cabeçalho da requisição
            headers : {
                "Content-Type" : "application/json"
            }
        })

        // Exibe no console do navegador a mensagem "Tipo de Evento cadastrado!"
        .then(console.log('Tipo de Evento cadastrado!'))

        // Caso ocorra algum erro, exibe este erro no console do navegador
        .catch(erro => console.log(erro))

        // Então, atualiza a lista de Tipos de Evento 
        // sem o usuário precisar executar outra ação
        .then(this.buscarTiposEventos)
    }

    // Chama a função buscarTiposEventos() assim que o componente é renderizado
    componentDidMount(){
        this.buscarTiposEventos();
    }

    render(){
        return(
            <div>
                <main>
                    <section>
                        {/* Lista de tipos de eventos  */}
                        <h2>Lista de tipos de eventos</h2>
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
                        {/* Cadastro de Tipo de Evento */}
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
        )
    }
}

export default TiposEventos;