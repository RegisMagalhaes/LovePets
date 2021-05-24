import { Component } from 'react';

class TiposEventos extends Component{
    constructor(props){
        super(props);
        this.state = {
            // nomeEstado : valorInicial
            listaTiposEventos : [],
            titulo : '',
            idTipoEventoAlterado : 0
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

        // Caso algum Tipo de Evento seja selecionado para edição,
        if (this.state.idTipoEventoAlterado !== 0) {
            // faz a chamada para a API usando fetch e passando o ID do Tipo de Evento que será atualizado na URL da requisição
            fetch('http://localhost:5000/api/tiposeventos/' + this.state.idTipoEventoAlterado, {
                // Define o método da requisição ( PUT )
                method : 'PUT',

                // Define o corpo da requisição especificando o tipo ( JSON )
                // Em outras palavras, converte o state para uma string JSON
                body : JSON.stringify({ tituloTipoEvento : this.state.titulo }),

                // Define o cabeçalho da requisição
                headers : {
                    "Content-Type" : "application/json"
                }
            })

            .then(resposta => {
                // Caso a requisição retorne um status code 204,
                if (resposta.status === 204) {
                    console.log(
                    // exibe no console do navegador a mensagem 'Tipo de Evento x atualizado!' onde x é o ID do Tipo de Evento que foi atualizado
                    'Tipo de Evento ' + this.state.idTipoEventoAlterado + ' atualizado!',
                    // e informa qual é o seu novo título
                    'Seu novo título agora é: ' + this.state.titulo
                    )
                }
            })

            // Então, atualiza a lista de Tipos de Evento 
            // sem o usuário precisar executar outra ação
            .then(this.buscarTiposEventos)

            // Faz a chamada para a função limparCampos()
            .then(this.limparCampos)
        } 
        else 
        {
            // Caso nenhum Tipo de Evento tenha sido selecionado para edição, realiza o cadastro com a requisição abaixo

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

        // Faz a chamada para a função limparCampos()
        .then(this.limparCampos)
        }
    }

    // Chama a função buscarTiposEventos() assim que o componente é renderizado
    componentDidMount(){
        this.buscarTiposEventos();
    }

    // Recebe um tipo de evento da lista
    buscarTipoEventoPorId = (tipoEvento) => {
        this.setState({
            // Atualiza o state idTipoEventoAlterado com o valor do ID do Tipo de Evento recebido
            idTipoEventoAlterado : tipoEvento.idTipoEvento,
            // e o state titulo com o valor do título do Tipo de Evento recebido
            titulo : tipoEvento.tituloTipoEvento
        }, () => {
            console.log(
                // Exibe no console do navegador o valor do ID do Tipo de Evento recebido
                'O Tipo de Evento ' + tipoEvento.idTipoEvento + ' foi selecionado,',
                // e o valor do state idTipoEventoAlterado
                'agora o valor do state idTipoEventoAlterado é: ' + this.state.idTipoEventoAlterado,
                // e o valor do state titulo
                'e o valor do state titulo é: ' + this.state.titulo
            );
        });
    };

    // Reseta os states titulo e idTipoEventoAlterado
    limparCampos = () => {
        this.setState({
            titulo : '',
            idTipoEventoAlterado : 0
        })

        // Exibe no console do navegador a mensagem 'Os states foram resetados!
        console.log('Os states foram resetados!')
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
                                    <th>Ações</th>{/* Ações */}
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

                                                {/* Faz a chamada da função buscarTipoEventoPorId passando o Tipo de Evento selecionado */}
                                                
                                                <td><button onClick={() => this.buscarTipoEventoPorId(tipoEvento)}>Editar</button></td>
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

                                {/* <button type="submit">Cadastrar</button> */}

                                {/* Estrutura do IF Ternário */}
                                {/* condição ? faço algo, caso seja verdadeiro : faço algo, caso seja falso */}

                                {/* Altera o botão de acordo com a operação ( edição ou cadastro ) usando IF Ternário */}

                                {/* {
                                    this.state.idTipoEventoAlterado === 0 ?
                                    <button type="submit">Cadastrar</button> :
                                    <button type="submit">Atualizar</button>
                                } */}

                                {/* Uma outra forma, com IF Ternário e disabled ao mesmo tempo */}

                                {
                                    <button type="submit" disabled={this.state.titulo === '' ? 'none' : ''} >
                                        {
                                            this.state.idTipoEventoAlterado === 0 ? 'Cadastrar' : 'Atualizar'
                                        }
                                    </button>
                                }

                                <button type="button" onClick={this.limparCampos}>
                                    Cancelar
                                </button>

                            </div>
                        </form>

                        {/* Caso algum Tipo de Evento tenha sido selecionado para edição, exibe a mensagem de feedback ao usuário */}

                        {
                            this.state.idTipoEventoAlterado !== 0 &&
                            <div>
                                <p>O tipo de evento {this.state.idTipoEventoAlterado} está sendo editado</p>
                                <p>Clique em Cancelar caso queira cancelar a operação antes de cadastrar um novo tipo de evento.</p>
                            </div>

                        }

                    </section>
                </main>
            </div>
        )
    }
}

export default TiposEventos;