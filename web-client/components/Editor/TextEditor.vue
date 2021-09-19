<template>
  <div class="d-flex">
    <v-col class="flex-grow-0">
      <v-card flat>
        <v-card-text>
          <v-row align="center" justify="center">
            <v-btn-toggle class="flex flex-column align-start">
              <v-btn>
                <v-icon>mdi-format-align-left</v-icon>
              </v-btn>
              <v-btn>
                <v-icon>mdi-format-align-center</v-icon>
              </v-btn>
              <v-btn>
                <v-icon>mdi-format-align-right</v-icon>
              </v-btn>
              <v-btn>
                <v-icon>mdi-format-align-justify</v-icon>
              </v-btn>
              <v-btn :class="{ 'primary': editor.isActive('bold') }"
                     v-on:click="editor.chain().toggleBold().focus().run()">
                <v-icon>mdi-format-bold</v-icon>
              </v-btn>
              <v-btn>
                <v-icon>mdi-format-italic</v-icon>
              </v-btn>
              <v-btn>
                <v-icon>mdi-format-underline</v-icon>
              </v-btn>
            </v-btn-toggle>
          </v-row>

        </v-card-text>
      </v-card>
    </v-col>
    <v-col>
      <div>
        <label class="d-block" v-on:click="editor.chain().focus()">Enter your text below</label>
        <hr>
        <editor-content :editor="editor"/>
      </div>
    </v-col>
  </div>
</template>

<script>
import {Editor, EditorContent} from '@tiptap/vue-2'
import StarterKit from '@tiptap/starter-kit'
import {mapState, mapMutations} from "vuex";

export default {
  name: "Editor",
  components: {
    EditorContent,
  },

  data() {
    return {
      editor: null,
    }
  },
  computed: {
    ...mapState('posts', ['posts']),
  },
  methods: {
    ...mapMutations('posts', ["setPosts"]),
    ...mapMutations('textEditor', ['setTextContent'])
  },
  async fetch() {
    this.editor = new Editor({
      extensions: [
        StarterKit,
      ],
      editorProps: {
        attributes: {
          class: 'flex px-2',
          style: 'min-height: 500px; border-left: 2px solid black; border-right: 2px solid black'
        },
      },
      onUpdate: () => {
        this.setTextContent({content: this.editor.getHTML()});
      },
    })
  },

  beforeDestroy() {
    this.editor.destroy()
  },
}
</script>

<style lang="scss">
.ProseMirror {
  p {
    margin: 1em 0;
  }
}
</style>
