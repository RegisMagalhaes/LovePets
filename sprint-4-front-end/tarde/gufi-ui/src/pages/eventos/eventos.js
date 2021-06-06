import { React, Component } from 'react';
import axios from 'axios';

export default class Eventos extends Component {
    constructor(props){
        super(props);
        this.state = {

        }
    }

    // Chama as funções assim que a tela é renderizada
    componentDidMount(){

    };

    render(){
        <>
            <main>
                <section>
                    {/* Lista de Eventos */}
                    <h2>Lista de Eventos</h2>
                    <table>
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Evento</th>
                                <th>Data</th>
                                <th>Acesso Livre</th>
                                <th>Tipo de Evento</th>
                            </tr>
                        </thead>

                        <tbody>

                        </tbody>
                    </table>
                </section>

                <section>
                    {/* Cadastro de Eventos */}
                    <h2>Cadastro de Eventos</h2>
                </section>
            </main>
        </>
    };
};