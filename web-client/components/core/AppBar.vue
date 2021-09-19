<template>
  <v-app-bar app flat>
    <v-app-bar-nav-icon class="hidden-md-and-up"/>

    <v-container class="mx-auto py-0">
      <v-row align="center">
        <nuxt-link to="/home" class="d-flex">
          <v-img :src="require('@/assets/logo.png')" class="mr-5" contain height="48" width="48" max-width="48"/>
          <h1>The Rooms</h1>
        </nuxt-link>

        <v-spacer/>

        <nuxt-link to="Create">
          <v-btn depressed class="mr-8">Create post</v-btn>
        </nuxt-link>
        <nuxt-link to="Home">
          <v-btn depressed class="mr-8">Home</v-btn>
        </nuxt-link>

        <v-text-field append-icon="mdi-magnify" flat hide-details solo-inverted style="max-width: 300px;"/>
      </v-row>
    </v-container>
  </v-app-bar>
</template>

<script>

export default {
  name: 'CoreAppBar',
}
</script>
