<template>
  <section>
    <feed>
      <slot/>
    </feed>
  </section>
</template>

<script>
import Feed from "@/components/Feed";

export default {
  name: 'HomeAbout',
  components: {
    Feed
  },
}
</script>
