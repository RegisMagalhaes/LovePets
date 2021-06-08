import React, { useState, useEffect } from 'react';
import axios from 'axios';

export default function TiposUsuarios(){
    // Define os states e as funções que farão suas atualizações
    const [ listaTiposUsuarios, setListaTiposUsuarios ] = useState( [] );
    const [ titulo, setTitulo ] = useState( '' );

    // Mostra no console do navegador o valor do titulo
    console.log(titulo);

    // Função responsável por fazer a requisição e trazer a lista de tipos usuários
    function buscarTiposUsuarios(){
        // Faz a chamada para a API usando axios
        axios('http://localhost:5000/api/tiposusuarios', {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

        .then(resposta => {
            // Caso a resposta da requisição retorne um status code 200,
            if (resposta.status === 200) {
                // chama a função que atualiza o state da lista de tipos usuários
                setListaTiposUsuarios(resposta.data)
            }
        })

        // Caso ocorra algum erro, mostra o erro no console do navegador
        .catch(erro => console.log(erro));
    };

    // Neste caso, o efeito só é disparado uma vez, ou seja, a função buscarTiposUsuarios só é invocada uma vez porque não estamos escutando nada
    useEffect( buscarTiposUsuarios, [titulo] );

    function cadastrarTipoUsuario(event){
        event.preventDefault();

        axios.post('http://localhost:5000/api/tiposusuarios', {
            tituloTipoUsuario : titulo
        }, {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

        .then(resposta => {
            if (resposta.status === 201) {
                console.log('Tipo de Usuário cadastrado!');
                buscarTiposUsuarios();
            };
        })

        .catch(erro => console.log(erro));
    };

    return(
        <div>
            <main>
                <section>
                    <h2>Lista de Tipos Usuários</h2>
                    <div>
                        <table style={{ borderCollapse : 'separate', borderSpacing : 30 }}>
                            <thead>
                                <tr>
                                    <td>#</td>
                                    <td>Título</td>
                                </tr>
                            </thead>

                            <tbody>
                                {
                                    listaTiposUsuarios.map( (tipoUsuario) => {
                                        return(
                                            <tr key={tipoUsuario.idTipoUsuario}>
                                                <td>{tipoUsuario.idTipoUsuario}</td>
                                                <td>{tipoUsuario.tituloTipoUsuario}</td>
                                            </tr>
                                        );
                                    } )
                                }
                            </tbody>
                        </table>
                    </div>
                </section>

                <section>
                    <h2>Cadastro de Tipo de Usuário</h2>
                    <form onSubmit={cadastrarTipoUsuario}>
                        <div>
                            <input 
                                // Título
                                type="text"
                                value={titulo}
                                onChange={(event) => setTitulo(event.target.value)}
                                placeholder="Título Tipo Usuário"
                            />

                            <button type="submit">Cadastrar</button>
                        </div>
                    </form>
                </section>
            </main>
        </div>
    )
};