<template>
  <v-app dark>
    <v-main>
      <v-container>
        <Nuxt />
      </v-container>
    </v-main>
      <span>&copy; {{ new Date().getFullYear() }}</span>
  </v-app>
</template>

<script>
export default {
  data () {
  }
}
</script>
