import React, { Component } from 'react';
import { FlatList, Image, StyleSheet, Text, View } from 'react-native';

import api from './src/services/api';

export default class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      listaEventos : []
    }
  }

  buscarEventos = async () => {
    const resposta = await api.get('/eventos');
    // const dadosDaApi = resposta.data;
    this.setState({ listaEventos : resposta.data })
    console.log(this.state.listaEventos)
  }

  componentDidMount() {
    // Realiza a chamada para a API trazendo todos os eventos
    this.buscarEventos();
  }

  render(){
    return (
      <View style={styles.main}>

        {/* Cabeçalho - Header */}
        <View style={styles.mainHeader}>
          <View style={styles.mainHeaderRow}>
            <Image 
              source={require('./assets/img/calendar.png')}
              style={styles.mainHeaderImg}
            />
            <Text style={styles.mainHeaderText}>{"Eventos".toUpperCase()}</Text>
          </View>
          <View style={styles.mainHeaderLine} />
        </View>

        {/* Corpo - Body - Section */}
        <View style={styles.mainBody}>
          <FlatList
            contentContainerStyle={styles.mainBodyContent}
            data={this.state.listaEventos}
            keyExtractor={ item => item.nomeEvento }
            renderItem={this.renderItem}
          />
        </View>
        
      </View>
    );
  }

  renderItem = ({ item }) => (
    // <Text style={{ fontSize: 20, color: 'red' }}>{item.nomeEvento}</Text>

    <View style={styles.flatItemRow}>
      <View style={styles.flatItemContainer}>
        <Text style={styles.flatItemTitle}>{item.nomeEvento}</Text>
        <Text style={styles.flatItemInfo}>{item.descricao}</Text>
        <Text style={styles.flatItemInfo}>{item.dataEvento}</Text>
      </View>

      <View style={styles.flatItemImg}>
        <Image 
          source={require('./assets/img/view.png')}
          style={styles.flatItemImgIcon}
        />
      </View>
    </View>
  )

}

const styles = StyleSheet.create({

  main: {
    flex: 1,
    backgroundColor: '#F1F1F1'
  },


  // cabeçalho
  mainHeader : {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    // backgroundColor: 'blue'
  },
  mainHeaderRow: {
    flexDirection: 'row'
  },
  // imagem do cabeçalho
  mainHeaderImg: {
    width: 22,
    height: 22,
    tintColor: '#ccc',
    marginRight: -5,
    marginTop: -12
  },
  // texto do cabeçalho
  mainHeaderText: {
    fontSize: 16,
    letterSpacing: 5,
    color: '#999',
    fontFamily: 'Open Sans'
  },
  // linha de separação do cabeçalho
  mainHeaderLine: {
    width: 220,
    paddingTop: 10,
    borderBottomColor: '#999',
    borderBottomWidth: 1
  },


  // conteúdo do body
  mainBody: {
    flex: 4,
    // backgroundColor: 'red'
  },
  // conteúdo da lista
  mainBodyContent: {
    paddingTop: 30,
    paddingRight: 50,
    paddingLeft: 50
  },
  flatItemRow: {
    flexDirection: 'row',
    borderBottomWidth: 1,
    borderBottomColor: '#ccc',
    marginTop: 30
  },
  flatItemContainer: {
    flex: 1
  },
  flatItemTitle: {
    fontSize: 16,
    color: '#333',
    fontFamily: 'Open Sans Light'
  },
  flatItemInfo: {
    fontSize: 12,
    // #RRGGBB
    // #RGB
    color: '#999',
    lineHeight: 20
  },
  flatItemImg: {
    justifyContent: 'center'
  },
  flatItemImgIcon: {
    width: 26,
    height: 26,
    tintColor: '#B727FF'
  }

});
