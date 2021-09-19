<template>
  <v-container
    id="social"
    tag="section"
  >
    <v-row>
      <v-col
        cols="12"
        md="4"
      >
        <instagram />
      </v-col>

      <v-col
        cols="12"
        md="4"
      >
        <newest-posts />
      </v-col>

      <v-col
        cols="12"
        md="4"
      >
        <tags />
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import Instagram from "@/components/Instagram";
import NewestPosts from "@/components/NewestPosts";
import Tags from "@/components/Tags";
  export default {
    name: 'HomeSocial',

    components: {
      Instagram,
      NewestPosts,
      Tags
    },
  }
</script>
