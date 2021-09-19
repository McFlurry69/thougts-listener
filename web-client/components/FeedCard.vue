<template>
  <v-col cols="12" :md="size === 2 ? 6 : size === 3 ? 4 : undefined">
    <v-card :height="value.prominent ? 450 : 350" color="grey lighten-1" dark href="#!">
      <v-img :src="`http://localhost:5000/api/images/${value.headerImage}`" height="100%"
             gradient="rgba(0, 0, 0, .42), rgba(0, 0, 0, .42)">
        <v-row class="fill-height ma-0">
          <v-col cols="12">
            <v-row>
              <v-card-title class="text-h3 font-weight-bold mb-2">
                {{ value.title }}
              </v-card-title>
            </v-row>
            <v-row>
            <v-card-subtitle>
              {{ value.subTitle }}
            </v-card-subtitle>
              </v-row>

            <v-row>
            <v-chip v-for="cat in value.categories" :key="cat" label class="mx-3 b-2 text-uppercase align-self-end"
                    color="grey darken-3" text-color="white" small>
              <span>{{ cat }}</span>
            </v-chip>
              </v-row>
          </v-col>
        </v-row>
      </v-img>
    </v-card>
  </v-col>
</template>

<script>
export default {
  name: 'FeedCard',

  props: {
    size: {
      type: Number,
      required: true,
    },
    value: {
      type: Object,
      default: () => ({}),
    },
  },
}
</script>

<style>
.v-image__image {
  transition: .3s linear;
}
</style>
