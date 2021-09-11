<template>
  <v-row justify="center" align="center">
    <v-col cols="12" sm="8" md="6">
      <v-card>
        <v-card-title class="headline">
          Hi
        </v-card-title>
        <v-card-text>
          There
          <p>{{message}}</p>
        </v-card-text>
      </v-card>
    </v-col>
  </v-row>
</template>

<script>
import Axios from 'axios'

export default {
  data: () => ({
    message: ""
  }),
  asyncData(payload){
    return Axios.get("http://localhost:5000/api/home").then(({data}) => {
      return { message: data}
    })
  },
  created() {

  }
}
</script>
