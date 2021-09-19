<template>
  <v-footer
    class="py-4"
    dark
    height="auto"
  >
    <v-container class="mx-auto">
      <v-row>
        <v-col cols="9">
          <v-btn
            v-for="(item, i) in items"
            :key="i"
            :href="item.href"
            class="ml-0 mr-3"
            color="primary"
            square
            target="_blank"
          >
            <v-icon v-text="item.icon" />
          </v-btn>
        </v-col>

        <v-spacer />

        <v-btn
          class="mr-0"
          square
          title="Go to top"
          @click="$vuetify.goTo(0)"
        >
          <v-icon>mdi-chevron-up</v-icon>
        </v-btn>
      </v-row>
    </v-container>
  </v-footer>
</template>

<script>
  export default {
    name: 'CoreFooter',

    data: () => ({
      items: [
        {
          href: '#!',
          icon: 'mdi-twitter',
        },
        {
          href: '#!',
          icon: 'mdi-instagram',
        },
        {
          href: '#!',
          icon: 'mdi-facebook',
        },
        {
          href: '#!',
          icon: 'mdi-google-plus',
        },
        {
          href: '#!',
          icon: 'mdi-reddit',
        },
        {
          href: '#!',
          icon: 'mdi-discord',
        },
        {
          href: '#!',
          icon: 'mdi-pinterest',
        },
      ],
    }),
  }
</script>
