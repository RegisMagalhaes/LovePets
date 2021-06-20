import React, { Component } from 'react';
import { Image, StyleSheet, Text, TouchableOpacity, View } from 'react-native';

export default class Perfil extends Component {

  render(){
    return (
      <View style={styles.main}>

        {/* Cabeçalho - Header */}
        <View style={styles.mainHeader}>
          <View style={styles.mainHeaderRow}>
            <Image 
              source={require("../../assets/img/profile.png")}
              style={styles.mainHeaderImg}
            />
            <Text style={styles.mainHeaderText}>{"Perfil".toUpperCase()}</Text>
          </View>
          <View style={styles.mainHeaderLine} />
        </View>

        {/* Corpo - Body - Section */}
        <View style={styles.mainBody}>
          <View style={styles.mainBodyInfo}>
            {/* <Image 
              source={imagem vinda da API}
              style={styles.mainBodyImg}
            /> */}
            <View style={styles.mainBodyImg} />

            <Text style={styles.mainBodyText}>Nome</Text>
            <Text style={styles.mainBodyText}>E-mail</Text>
          </View>

          <TouchableOpacity
            style={styles.btnLogout}
            onPress={this.realizarLogout}
          >
              <Text style={styles.btnLogoutText}>Logout</Text>
          </TouchableOpacity>
        </View>
        
      </View>
    );
  }
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
    flex: 4,
    alignItems: 'center',
    justifyContent: 'space-between'
  },
  // informações do usuário
  mainBodyInfo: {
    alignItems: 'center'
  },
  mainBodyImg: {
    backgroundColor: '#ccc',
    width: 100,
    height: 100,
    borderRadius: 50,
    marginBottom: 50
  },
  mainBodyText: {
    color: '#999',
    fontSize: 16,
    marginBottom: 20
  },
  // botão de logout
  btnLogout: {
    alignItems: "center",
    justifyContent: "center",
    height: 38,
    width: 240,
    backgroundColor: "#FFFFFF",
    borderColor: "#FFFFFF",
    borderWidth: 1,
    borderRadius: 4,
    shadowOffset: { height: 1, width: 1 },
    marginBottom: 50
  },
  // texto do botão
  btnLogoutText: {
    fontSize: 12,
    fontFamily: "Open Sans Light",
    color: "#B727FF",
    letterSpacing: 6,
    textTransform: 'uppercase'
  }

});