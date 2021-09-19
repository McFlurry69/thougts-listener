<template>
  <v-app light>
    <AppBar />
    <v-main>
      <v-container>
        <Nuxt />
      </v-container>
    </v-main>
    <Footer/>
  </v-app>
</template>


<script>
import AppBar from "@/components/core/AppBar";
import Footer from "@/components/core/Footer";

export default {
  components:{
    AppBar,
    Footer
  }
}
</script>
