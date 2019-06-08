<template>
  <div class="box">
    <h1>DETETIVE</h1>
    <p>
      Bem-vindo, inspetor Jacques Clouseau! Daremos início as investigações do assassinato do empresário Sean Bean!
      <br><br>
      Vamos interrogar uma testemunha, e para refrescar sua memória, por favor escolha um suspeito, local e arma, de acordo com o que conseguimos coletar até agora.

    </p>
    <hr>
    <button class="btn btn-inicio" v-if="!iniciado" @click="iniciaInterrogatorio()">
      Iniciar interrogatório
    </button>
    <div v-if="iniciado && !finalizado">
      <label>Suspeito:</label>
      <select v-model="teoria.suspeito">
        <option v-for="Suspeito in Suspeitos" v-bind:value="Suspeito.id">
          {{Suspeito.nome}}
        </option>
      </select>
      <br><br>
      <label>Local:</label>
      <select v-model="teoria.local">
        <option v-for="Local in Locais" v-bind:value="Local.id">
          {{Local.nome}}
        </option>
      </select>
      <br><br>
      <label>Arma:</label>
      <select v-model="teoria.arma">
        <option v-for="Arma in Armas" v-bind:value="Arma.id">
          {{Arma.nome}}
        </option>
      </select>
      <br><br>
      <button class="btn btn-interrogar" @click="retornoDaTeoria()">
        Interrogar testemunha
      </button>
      <hr>
      <div v-if="respondido" class="box-incorreto">
        <p>{{resultado}}</p>
      </div>
    </div>
    <div v-if="finalizado">
      <div class="box-finalizado">
      <p>
      {{resultado}}
      </P>
      </div>
      <br>
      <button class="btn" @click="novoCaso()">
        Resolver um novo caso!
      </button>
    </div>
  </div>
</template>

<script>
export default {
  data(){
    return{
      teoria: {
        suspeito: 1,
        local: 1,
        arma: 1,
      },
      SuspeitoSelected: 0,
      LocalSelected: 0,
      ArmaSelected: 0,
      Suspeitos: [],
      Locais: [],
      Armas: [],
      iniciado: false,
      finalizado: false,
      respondido: false,
      resultado: '',
      respostaIncorreta: []
    }
  },
  created(){
    this.$http.get('http://localhost:3000/Suspeitos')
    .then(res => res.json())
    .then(suspeitos => this.Suspeitos = suspeitos);

    this.$http.get('http://localhost:3000/Locais')
    .then(res => res.json())
    .then(locais => this.Locais = locais);

    this.$http.get('http://localhost:3000/Armas')
    .then(res => res.json())
    .then(armas => this.Armas = armas);
  },
  props: {
  },
  methods:{
    iniciaInterrogatorio(){    
      do{
          this.SuspeitoSelected = Math.floor(Math.random() * this.Suspeitos.length);

          this.LocalSelected = Math.floor(Math.random() * this.Locais.length);
        
          this.ArmaSelected = Math.floor(Math.random() * this.Armas.length);

      }while(this.SuspeitoSelected == 0 || this.LocalSelected == 0 || this.ArmaSelected == 0);

      this.iniciado = true;
    },

    novoCaso(){
      this.iniciado = false;
      this.finalizado = false;
      this.resultado = "";
      this.teoria.suspeito = 1;
      this.teoria.local = 1;
      this.teoria.arma = 1;
    },

    retornoDaTeoria(){
      this.respondido = true;
      this.respostaIncorreta = [];
      if(this.teoria.suspeito == this.SuspeitoSelected &&
         this.teoria.local == this.LocalSelected &&
         this.teoria.arma == this.ArmaSelected){
        this.finalizado = true;
        this.resultado = "Parabéns inspetor! Você solucionou o caso!";
      }
      else{
        if(this.teoria.suspeito != this.SuspeitoSelected){
          this.respostaIncorreta.push("Suspeito incorreto!");
        }
        if(this.teoria.local != this.LocalSelected){
          this.respostaIncorreta.push("Local incorreto!");
        }
        if(this.teoria.arma != this.ArmaSelected){
          this.respostaIncorreta.push("Arma incorreta!");
        }
        //console.log("Suspeito: " + this.SuspeitoSelected + "\nLocal: " + this.LocalSelected + "\nArma:" + this.ArmaSelected);
        this.resultado = this.respostaIncorreta[Math.floor(Math.random() * this.respostaIncorreta.length)];
      }
    }

  }
  
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->

<style>
body{
  font-family: Tahoma;
}

.box{
  text-align: center;
  border: 1px solid;
  padding: 10px;
  margin: 5%;
}

.box p{
  margin: 50px;
}

.box-finalizado{
  background-color: #99DDC8;
  padding: 20px 0;
}

.box-incorreto{
  background-color: #E56D6B;
  padding: 20px 0;
}

.btn{
  padding: 15px;
  cursor: pointer;
  border-radius: 5px;
  background-color: #03254E;
  color: white;
  border: 1px solid #03254E;
}

.btn:hover{
  background-color: white;
  color: #03254E;
}

.box label{
  font-weight: bold;
  margin-right: 10px;
}

.box select{
  border-radius: 5px;
  height: 25px;
}


</style>