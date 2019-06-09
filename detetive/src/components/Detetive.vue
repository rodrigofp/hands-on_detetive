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
      <select v-model="teoria.SuspeitoId">
        <option v-for="Suspeito in Suspeitos" v-bind:value="Suspeito.id">
          {{Suspeito.nome}}
        </option>
      </select>
      <br><br>
      <label>Local:</label>
      <select v-model="teoria.LocalId">
        <option v-for="Local in Locais" v-bind:value="Local.id">
          {{Local.nome}}
        </option>
      </select>
      <br><br>
      <label>Arma:</label>
      <select v-model="teoria.ArmaId">
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
        Id: 0,
        SuspeitoId: 1,
        LocalId: 1,
        ArmaId: 1,
      },
      Suspeitos: [],
      Locais: [],
      Armas: [],
      iniciado: false,
      finalizado: false,
      respondido: false,
      resultado: '',
      resposta: 4
    }
  },
  created(){
    this.$http.get('http://localhost:5000/api/suspeitos')
    .then(res => res.json())
    .then(suspeitos => this.Suspeitos = suspeitos);

    this.$http.get('http://localhost:5000/api/locais')
    .then(res => res.json())
    .then(locais => this.Locais = locais);

    this.$http.get('http://localhost:5000/api/armas')
    .then(res => res.json())
    .then(armas => this.Armas = armas);
  },
  props: {
  },
  methods:{
    iniciaInterrogatorio(){
      let solucao = {
        SuspeitoId: 0,
        LocalId: 0,
        ArmaId: 0
      }

      do{
          solucao.SuspeitoId = Math.floor(Math.random() * this.Suspeitos.length);

          solucao.LocalId = Math.floor(Math.random() * this.Locais.length);

          solucao.ArmaId = Math.floor(Math.random() * this.Armas.length);

      }while(solucao.SuspeitoId == 0 || solucao.LocalId == 0 || solucao.ArmaId == 0);

      this.$http.post('http://localhost:5000/api/SolucaoCrimes', solucao)
      .then(res => res.json())
      .then(id => this.teoria.Id = id);

      console.log(this.teoria);
      console.log(solucao);

      this.iniciado = true;
    },

    novoCaso(){
      this.iniciado = false;
      this.finalizado = false;
      this.respondido = false;
      this.resultado = "";
      this.teoria.SuspeitoId = 1;
      this.teoria.LocalId = 1;
      this.teoria.ArmaId = 1;
    },

    retornoDaTeoria(){
      this.respondido = true;


      let solucao = {
        Id: this.teoria.Id,
        SuspeitoId: this.teoria.SuspeitoId,
        LocalId: this.teoria.LocalId,
        ArmaId: this.teoria.ArmaId
      };

      this.$http.put('http://localhost:5000/api/SolucaoCrimes', solucao)
      .then(res => res.json())
      .then(result => this.resposta = result);

      switch(this.resposta){
        case 0:
          this.resultado = "Parabéns inspetor, o sr. solucionou o caso! Deseja iniciar uma nova investigação?";
          this.finalizado = true;
          break;
        case 1:
          this.resultado = "Suspeito incorreto!";
          break;
        case 2:
          this.resultado = "Local incorreto!";
          break;
        case 3:
          this.resultado = "Arma incorreta!";
          break;
        default:
          this.resultado = this.resposta;
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