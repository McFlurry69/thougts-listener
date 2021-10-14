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
              <v-btn v-on:click="$refs.uploaderIm.click();" class="px-0 py-0">
                <v-icon>mdi-arrow-up-bold-box-outline</v-icon>
              </v-btn>
              <v-btn v-on:click="$refs.uploaderVid.click();" class="px-0 py-0">
                <v-icon>mdi-arrow-up-bold-box-outline</v-icon>
              </v-btn>
              <input ref="uploaderIm" v-show="false" type="file" accept="image/*" v-on:change="handleFile"/>
              <input ref="uploaderVid" v-show="false" type="file" accept="video/*" v-on:change="handleFile"/>

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
import {mapState, mapMutations, mapActions} from "vuex";
import Image from '@tiptap/extension-image'
import {FILE_TYPE} from "@/data/enum.js";

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
    ...mapState("images", ["uploadPromise"]),
    uploadFileType: () => FILE_TYPE
  },
  methods: {
    ...mapMutations('images', ['setType']),
    ...mapMutations('posts', ["setPosts"]),
    ...mapMutations('textEditor', ['setTextContent']),
    ...mapActions("images", ["createImageTask"]),
    async handleFile(event) {
      const file = event.target.files[0];
      if (!file) return;
      const form = new FormData();
      form.append(FILE_TYPE, file);
      this.createImageTask({form});

      if (!this.uploadPromise) {
        return;
      }

      const result = await this.uploadPromise;
      console.log(result);
      this.editor.chain().focus().setImage({src: `http://localhost:5000/api/${FILE_TYPE}/` + result}).run()
    }
  },
  async fetch() {
    this.editor = new Editor({
      extensions: [
        StarterKit,
        Image,
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
  padding-top: 8px;
  padding-bottom: 50px;

  p {
    margin: 0;
  }

  img {
    width: 600px;
    display: block;
    margin: auto;
  }
}
</style>
