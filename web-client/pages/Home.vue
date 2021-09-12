<template>
  <div>
 <Articles>
      <Banner />
    </Articles>
<!--
    <About />

    <Subscribe />

    <Social />-->
  </div>
</template>

<script>
import Articles from "@/components/home/Articles";
import Banner from "@/components/home/Banner";
import About from "@/components/home/About";
import Social from "@/components/home/Social";
import Subscribe from "@/components/home/Subscribe";

  export default {
    components: {
      Articles,
      Banner,
      About,
      Subscribe,
      Social
    }
  }
</script>
