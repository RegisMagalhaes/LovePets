import { Component } from 'react';

class TiposEventos extends Component{
    constructor(props){
        super(props);
        this.state = {
            // nomeEstado : valorInicial
            listaTiposEventos : [ { tipoEventoId : 1, titulo : 'C#' }, { tipoEventoId : 2, titulo : 'ReactJs' }, { tipoEventoId : 3, titulo : 'UX / UI' } ],
            titulo : ''
        }
    }

    componentDidMount(){
        // código
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
                                    <th>#</th> {/* IDs */}
                                    <th>Título</th> {/* Títulos */}
                                </tr>
                            </thead>

                            <tbody>
                                {
                                    this.state.listaTiposEventos.map( (tipoEvento) => {
                                        return (
                                            <tr key={tipoEvento.tipoEventoId}>
                                                <td>{tipoEvento.tipoEventoId}</td>
                                                <td>{tipoEvento.titulo}</td>
                                            </tr>
                                        )
                                    } )
                                }
                            </tbody>
                        </table>
                    </section>
                </main>
            </div>
        )
    }
}

export default TiposEventos;