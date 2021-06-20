import React, { Component } from 'react';
import { FlatList, Image, StyleSheet, Text, View } from 'react-native';

import api from '../services/api';

export default class Convites extends Component {
  constructor(props) {
    super(props);
    this.state = {
      listaMeusEventos: []
    };
  }

  buscarMeusEventos = async () => {
    const resposta = await api.get("/eventos");
    const dadosDaApi = resposta.data;
    this.setState({ listaMeusEventos : dadosDaApi });
  };

  componentDidMount() {
    // realizar a chamada a api
    this.buscarMeusEventos();
  }

  render(){
    return (
      <View style={styles.main}>

        {/* Cabeçalho - Header */}
        <View style={styles.mainHeader}>
          <View style={styles.mainHeaderRow}>
            <Image 
              source={require("../../assets/img/plane.png")}
              style={styles.mainHeaderImg}
            />
            <Text style={styles.mainHeaderText}>{"Convites".toUpperCase()}</Text>
          </View>
          <View style={styles.mainHeaderLine} />
        </View>

        {/* Corpo - Body - Section */}
        <View style={styles.mainBody}>
          <FlatList 
            contentContainerStyle={styles.mainBodyContent}
            data={ this.state.listaMeusEventos }
            keyExtractor={ item => item.nomeEvento }
            renderItem={this.renderItem}
          />
        </View>

      </View>
    );
  }

  renderItem = ({ item }) => (

    <View style={styles.flatItemRow}>
      <View style={styles.flatItemContainer}>
        <Text style={styles.flatItemTitle}>{item.nomeEvento}</Text>
        <Text style={styles.flatItemInfo}>{item.descricao}</Text>
        <Text style={styles.flatItemInfo}>{item.dataEvento}</Text>
      </View>

      <View style={styles.flatItemImg}>
        <Image
          source={require("../../assets/img/view.png")}
          style={styles.flatItemImgIcon}
        />
      </View>
    </View>
  )
}

const styles = StyleSheet.create({

  // conteúdo da main
  main: {
    flex: 1,
    backgroundColor: '#F1F1F1'
  },
  // cabeçalho
  mainHeader: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center'
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
    flex: 4
  },
  // conteúdo da lista
  mainBodyContent: {
    paddingTop: 30,
    paddingRight: 50,
    paddingLeft: 50
  },
  // dados do evento de cada item da lista (ou seja, cada linha da lista)
  flatItemRow: {
    flexDirection: 'row',
    borderBottomWidth: 1,
    borderBottomColor: '#ccc',
    marginTop: 40
  },
  flatItemContainer: {
    flex: 1,
  },
  flatItemTitle: {
    fontSize: 16,
    color: '#333',
    fontFamily: 'Open Sans Light'
  },
  flatItemInfo: {
    fontSize: 12,
    color: '#999',
    lineHeight: 24
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